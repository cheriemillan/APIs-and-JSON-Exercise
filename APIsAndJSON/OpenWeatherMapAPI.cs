using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        //https://api.openweathermap.org/data/2.5/weather?zip=11717&appid={key}&units=imperial

        public static void GetTemp()
        {
            //Grab the appsettings file text
            var appsettingsText = File.ReadAllText("appsettings.json");
            
            //Turn the json into an object to grab the place I need (api key)
            var apiKey = JObject.Parse(appsettingsText)["key"].ToString();
            
            Console.WriteLine("Enter zip: ");

            var zip = Console.ReadLine();

            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";

            var client = new HttpClient();

            var jsonText = client.GetStringAsync(url).Result;

            var weatherObj = JObject.Parse(jsonText);
            
            Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}");
        }
    }
}
