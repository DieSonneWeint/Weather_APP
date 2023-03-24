using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace WpfAppWther
{
    internal class ModelV
    {
        Model model = new Model();
        HttpClient client = new HttpClient();

        string API = "d3b601a5292fe7374e161205cf54ca0f";
        string API2 = "E8PDDNGUQTG972373HU9DKM4U";
        string API3 = "9267ce2ca31d4d50861102445232401";
        string URI, URI2, URI3, URI4;
        private void CreateURI(string CityName)
        {
            URI = $"https://api.openweathermap.org/data/2.5/weather?q={CityName}&appid=d3b601a5292fe7374e161205cf54ca0f&units=metric";
            URI2 = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{CityName}/today?unitGroup=metric&key=E8PDDNGUQTG972373HU9DKM4U&contentType=json";
            URI3 = $"http://api.weatherapi.com/v1/current.json?key=9267ce2ca31d4d50861102445232401&q={CityName}&aqi=no";
            URI4 = $"http://api.weatherstack.com/current?access_key=3d339b07eb46691e2bdb4b0e056d4cb8&query={CityName}";
        }
        public async void ResponseMessage(string CityName)
        {
            CreateURI(CityName);
            HttpResponseMessage httpResponseMessage =  await client.GetAsync(URI);
            HttpResponseMessage httpResponseMessage2 = await client.GetAsync(URI2);
            HttpResponseMessage httpResponseMessage3 = await client.GetAsync(URI3);
            HttpResponseMessage httpResponseMessage4 = await client.GetAsync(URI4);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                model.AllWeatherAP.openWeather = await httpResponseMessage.Content.ReadFromJsonAsync<OpenWeather>();
            }   
            if (httpResponseMessage2.IsSuccessStatusCode)
            {
                model.AllWeatherAP.visCross = await httpResponseMessage2.Content.ReadFromJsonAsync<VisCrossWeather>();
            }

            if (httpResponseMessage3.IsSuccessStatusCode)
            {
                model.AllWeatherAP.weatherapi = await httpResponseMessage3.Content.ReadFromJsonAsync<WeatherApi>();
            }

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                model.AllWeatherAP.weatherstack = await httpResponseMessage4.Content.ReadFromJsonAsync<Weatherstack>();
            }                         
        }

        public  void LoadFile(string FileName)
        {
          
          FileStream file = File.OpenRead(FileName);
          model.LoadWeather(file);
            
        }
        public  void SaveFile(string FileName) 
        {
            FileStream file= new FileStream(FileName, FileMode.OpenOrCreate)  ;
            model.SaveWeather(file);
        }
        public void SaveFileData(string FileName)
        {
            FileStream file= new FileStream(FileName,FileMode.OpenOrCreate);
            model.SaveWeatherData(file);
        }
        public double? ReturnTempOpenWeather() 
        {
            if (model.AllWeatherAP.openWeather != null)
             return  model.AllWeatherAP.openWeather.main.temp;
            return null;
        }
        public string ReturnCityNameOpenWeather() 
        {
            if (model.AllWeatherAP.visCross != null)
            return model.AllWeatherAP.visCross.address;
            return "Null";
        }
        public double? ReturnTempVissCrossWeather() 
        {
            return model.AllWeatherAP.visCross.days[0].temp;
        }
        public string ReturnCityNameVissCross() 
        {
            return model.AllWeatherAP.visCross.address;
        }
        public double? ReturnTempWeatherApi()
        {
            return model.AllWeatherAP.weatherapi.current.temp_c;
        }
        public string? ReturnCityNameWeatherApi() 
        {
            return model.AllWeatherAP.weatherapi.location.name;
        }
        public double? ReturnTempWeatherStack() 
        {
            return model.AllWeatherAP.weatherstack.Current.temperature;
        }
        public string? ReturnCityNameWeatherStack() 
        {
            return model.AllWeatherAP.weatherstack.Location.name;
        }

        public double ReturnAverageTemp() // подсчет средней температуры
        {
            int del = 0;
            double? result = 0;
            if (ReturnTempVissCrossWeather() != null)
            {
                del++;
                result += ReturnTempVissCrossWeather();
            }

            if (ReturnTempWeatherApi() != null)
            {
                del++;
                result += ReturnTempWeatherApi();
            }
            if (ReturnTempOpenWeather() != null)
            {
                del++;
                result += ReturnTempOpenWeather();
            }
            if (ReturnTempWeatherStack() != null)
            {
                del++;
                result += ReturnTempWeatherStack();
            }
            return Convert.ToDouble(result/del);
        }
    }
}