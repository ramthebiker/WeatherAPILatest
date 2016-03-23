using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherAPI.Models
{
    public class WeatherData
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryImageURl { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<List> list { get; set; }
        public string WeatherIcon { get; set; }
        public string MinTemp { get; set; }
        public string MaxTemp { get; set; }
        public string DayTemp { get; set; }
        public string NightTemp { get; set; }
        public string Humidity { get; set; }
    }
}