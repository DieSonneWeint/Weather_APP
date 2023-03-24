using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWther
{
    public class Weatherstack
    {
        public Request Request { get; set; }
        public Locations Location { get; set; }
        public Currents Current { get; set; }
        public Forecast Forecast { get; set; }
    }

    public class Request
    {
        public string type { get; set; }
        public string query { get; set; }
        public string language { get; set; }
        public string unit { get; set; }
    }

    public class Locations
    {
        public string name { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone_id { get; set; }
        public string localtime { get; set; }
        public int localtime_epoch { get; set; }
        public string utc_offset { get; set; }
    }

    public class Currents
    {
        public string observation_time { get; set; }
        public int temperature { get; set; }
        public int weather_code { get; set; }
        public int wind_speed { get; set; }
        public int wind_degree { get; set; }
        public string wind_dir { get; set; }
        public int pressure { get; set; }
        public int precip { get; set; }
        public int humidity { get; set; }
        public int cloudcover { get; set; }
        public int feelslike { get; set; }
        public int uv_index { get; set; }
        public int visibility { get; set; }
    }

    public class Forecast
    {
        public _20190907 _20190907 { get; set; }
    }

    public class _20190907
    {
        public string date { get; set; }
        public int date_epoch { get; set; }
        public int mintemp { get; set; }
        public int maxtemp { get; set; }
        public int avgtemp { get; set; }
        public int totalsnow { get; set; }
        public float sunhour { get; set; }
        public int uv_index { get; set; }
    }

}