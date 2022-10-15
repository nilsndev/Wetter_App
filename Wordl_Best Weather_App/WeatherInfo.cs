using System;
using System.Collections.Generic;
using System.Text;

namespace Wordl_Best_Weather_App{
   public class WeatherInfo{
        public class root{
            public List<weather> weather { get; set; }
            public wind wind { get; set; }
            public clouds clouds { get; set; }
            public main main { get; set; }
            public double dt { get; set; }
            public int timezone { get; set; }
        }
        public class main{
            public double temp { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
        }
        public class wind{
            public double speed { get; set; }
        }
        public class clouds{
            public int all { get; set; }
        }
        public class sys{}
        public class weather{
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
   }
}

