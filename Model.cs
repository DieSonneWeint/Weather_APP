using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace WpfAppWther
{
    internal class Model
    {
        public AllWeatherAPI AllWeatherAP = new AllWeatherAPI();
        public async void SaveWeather(FileStream createStream) 
        {
           var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
           string test = createStream.Name;
           await JsonSerializer.SerializeAsync(createStream, AllWeatherAP, options);
           await createStream.DisposeAsync();
        }
        public  void LoadWeather (FileStream fileStream)
        {           
            AllWeatherAP=JsonSerializer.Deserialize<AllWeatherAPI>(fileStream);
            fileStream.Close();
         
        }
        public async void SaveWeatherData(FileStream fileStream) 
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string test = fileStream.Name; 
            await JsonSerializer.SerializeAsync(fileStream, AllWeatherAP, options);
            await fileStream.DisposeAsync();
        }
    }
}
