using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjMVC.Models;
using System.Text.Json.Serialization;

namespace ProjMVC.Controllers
{
    public class WeatherController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7139/api");
        private readonly HttpClient _client;

        public WeatherController()
        {
            _client= new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<WeatherForecast> forecasts = new List<WeatherForecast>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/weatherforecast/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                forecasts = JsonConvert.DeserializeObject<List<WeatherForecast>>(data);
            }
            return View(forecasts);
        }
    }
}
