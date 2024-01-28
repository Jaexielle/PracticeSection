using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectAPI;
using ProjectAPI.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectMVC.Controllers
{
    public class StudentInfoController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44385/api");
        private readonly HttpClient _client;

        public StudentInfoController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<StudentInfo> forecasts = new List<StudentInfo>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/studentinfo/GetStudentInfos").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                forecasts = JsonConvert.DeserializeObject<List<StudentInfo>>(data);
            }
            return View(forecasts);
        }
    }
}
