using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWther
{
    public class VisCrossWeather
    {

        public int queryCost { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string resolvedAddress { get; set; }
        public string address { get; set; }
        public string timezone { get; set; }
        public float tzoffset { get; set; }
        public string description { get; set; }
        public Day[] days { get; set; }
        public object[] alerts { get; set; }     
        public Currentconditions currentConditions { get; set; }
    }
  
        public class Currentconditions
        {
            public string datetime { get; set; }
            public int datetimeEpoch { get; set; }
            public float temp { get; set; }
            public float feelslike { get; set; }
            public float humidity { get; set; }
           
        }

        public class Day
        {
            public string datetime { get; set; }
            public int datetimeEpoch { get; set; }
            public float tempmax { get; set; }
            public float tempmin { get; set; }
            public float temp { get; set; }
            public float feelslikemax { get; set; }
            public float feelslikemin { get; set; }
            public float feelslike { get; set; }            
           //public Hour[] hours { get; set; }         
            public DateTime datetimeInstance { get; set; }
        }

        public class Hour
        {
            public string datetime { get; set; }
            public int datetimeEpoch { get; set; }
            public float temp { get; set; }
            public float feelslike { get; set; }
            public float humidity { get; set; }          
            public DateTime datetimeInstance { get; set; }
        }

    
}
