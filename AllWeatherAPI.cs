using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWther
{
    public class AllWeatherAPI
    {
        public OpenWeather openWeather { get; set; }
        public Weatherstack weatherstack { get; set; } 
        public WeatherApi weatherapi { get; set; } 
        public VisCrossWeather visCross { get; set; } 
    }
}
