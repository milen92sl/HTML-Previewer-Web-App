namespace HTML_Previewer_Web_App.Services.Conversions
{
    using HTML_Previewer_Web_App.Data.Models;
    using Newtonsoft.Json;
    using System.Text;

    public class Convert : IConvert
    {
        public decimal ConvertBytesToMegabytes(string text)
             => (decimal)Encoding.Unicode.GetByteCount(text) / 1048576;
    }
}
