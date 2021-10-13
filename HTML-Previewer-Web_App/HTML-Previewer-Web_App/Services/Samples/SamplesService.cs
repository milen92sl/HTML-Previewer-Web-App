namespace HTML_Previewer_Web_App.Services.Samples
{
    using HTML_Previewer_Web_App.Data;
    using HTML_Previewer_Web_App.Data.Models;
    using HTML_Previewer_Web_App.Services.Samples.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SamplesService : ISamplesService
    {
        private const string DateTimeFormat = "MM/dd/yyyy hh:mm tt";

        private readonly ApplicationDbContext data;

        public SamplesService(ApplicationDbContext data)
            => this.data = data;

        public IEnumerable<SampleInfoServiceModel> All(string userId)
            => this.data
              .Samples
              .Where(s => s.UserId == userId)
              .Select(s => new SampleInfoServiceModel
              {
                  Id = s.Id,
                  Creation = s.Creation.ToString(DateTimeFormat),
                  LastEdit = s.LastEdit.ToString(DateTimeFormat)
              })
              .ToList();
        

        public bool CheckOriginal(string sampleId, string newCode)
        {
            var sampleCode = this.data
                .Samples
                .Where(s => s.Id == sampleId)
                .Select(s => s.Code)
                .FirstOrDefault();

            return sampleCode == newCode;
        }

        public void Edit(string sampleId, string code, string userId)
        {
            var sample = this.data
                .Samples
                .Find(sampleId);

            sample.Code = code;
            sample.LastEdit = DateTime.Now;

            this.data.SaveChanges();
        }

        public bool IsSampleExist(string sampleId, string userId)
           =>  this.data
              .Samples
              .Any(s => s.Id == sampleId && s.UserId == userId);


        public SampleCodeServiceModel SampleCode(string sampleId)
            => this.data
                .Samples
                .Where(s => s.Id == sampleId)
                .Select(s => new SampleCodeServiceModel
                {
                    Code = s.Code
                })
                .FirstOrDefault();


        public void Save(string code, string userId)
        {
            var sample = new Sample
            {
                Code = code,
                UserId = userId,
                Creation = DateTime.Now,
                LastEdit = DateTime.Now
            };

            this.data.Samples.Add(sample);

            this.data.SaveChanges();
        }
    }
}
