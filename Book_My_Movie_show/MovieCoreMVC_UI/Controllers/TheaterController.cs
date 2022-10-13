using Book_Show_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMVC_UI.Controllers
{
    public class TheaterController : Controller
    {
        private IConfiguration _configuration;
        public TheaterController(IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TheaterEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TheaterEntry(Theater theater)
        {
            ViewBag.staus = "";
            using(HttpClient client=new HttpClient())
            {
                StringContent Content=new StringContent(JsonConvert.SerializeObject(theater),Encoding.UTF8,"application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "Theater/AddTheater";
                using(var response=await client.PostAsync(endpoint, Content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theater Inserted succesfully";
                    }
                    else{
                        ViewBag.status = "Error";
                        ViewBag.message = "Error Happened";

                    }
                }
            }

            return View();
        }
    }
}
