using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWther
{
   public class WeatherApi
    {

        public Location location { get; set; }
        public Current current { get; set; }
    } 

        public class Location
        {
            public string name { get; set; }
            public string region { get; set; }
            public string country { get; set; }
            public float lat { get; set; }
            public float lon { get; set; }
            public string tz_id { get; set; }
            public int localtime_epoch { get; set; }
            public string localtime { get; set; }
        }

        public class Current
        {
            public int last_updated_epoch { get; set; }
            public string last_updated { get; set; }
            public float temp_c { get; set; }
        }
   
}
