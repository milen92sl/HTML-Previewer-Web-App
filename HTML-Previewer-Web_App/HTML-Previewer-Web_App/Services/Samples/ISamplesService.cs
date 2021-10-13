namespace HTML_Previewer_Web_App.Services.Samples
{
    using HTML_Previewer_Web_App.Services.Samples.Models;
    using System.Collections.Generic;

    public interface ISamplesService
    {
        void Save(string code, string userId);

        void Edit(string sampleId, string code, string userId);

        bool IsSampleExist(string sampleId, string userId);

        bool CheckOriginal(string sampleId, string newCode);

        SampleCodeServiceModel SampleCode(string sampleId);

        IEnumerable<SampleInfoServiceModel> All(string userId);
    }
}
