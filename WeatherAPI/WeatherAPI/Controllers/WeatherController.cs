using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    public class WeatherController : ApiController
    {
        // GET: api/Weather
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Weather/5
        public List<WeatherData> Get(string location)
        {
            List<WeatherData> list = new List<WeatherData>();
              string appId = "0d1f60e6b0b8470f6e3ff11010f28870";
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt=1&APPID={1}", location, appId);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                WeatherData weatherData = new WeatherData();
                WeatherInfo weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(json);
                weatherData.City = weatherInfo.city.name;
                weatherData.Country = weatherInfo.city.country;
                weatherData.Location = weatherInfo.city + "," + weatherInfo.city.country;
                weatherData.CountryImageURl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfo.city.country.ToLower());
                weatherData.Description = weatherInfo.list[0].weather[0].description;
                weatherData.WeatherIcon = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfo.list[0].weather[0].icon);
                weatherData.MinTemp = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.min, 1));
                weatherData.MaxTemp = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.max, 1));
                weatherData.DayTemp = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.day, 1));
                weatherData.NightTemp = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.night, 1));
                weatherData.Humidity = weatherInfo.list[0].humidity.ToString();
                list.Add(weatherData);

            }
            return list;
        }

        // POST: api/Weather
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Weather/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Weather/5
        public void Delete(int id)
        {
        }
    }
}
