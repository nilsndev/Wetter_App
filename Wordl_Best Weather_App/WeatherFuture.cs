using System;
using System.Collections.Generic;
using System.Text;

namespace Wordl_Best_Weather_App
{
    public class WeatherFuture{
        public class list{
            public int dt { get; set; }
            public main main { get; set; }
            public List<weather> weather { get; set; }
            public clouds clouds { get; set; } 
            public wind wind { get; set; }
            public string dt_txt { get; set; }
        }
        public class main{
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public int preassure { get; set; }
        }
        public class weather{
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
        public class clouds{
            public int all { get; set; }
        }
        public class wind{
            public double speed { get; set; }
        }
        public class root{
            public string cod { get; set; }
            public int message { get; set; }
            public int cnt { get; set; }
            public List<list> list { get; set; }
        }

    }
}

