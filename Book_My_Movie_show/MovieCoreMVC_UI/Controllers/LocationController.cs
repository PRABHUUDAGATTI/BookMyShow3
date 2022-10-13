using Book_Show_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMVC_UI.Controllers
{
    public class LocationController : Controller
    {
        private IConfiguration _configuration;
        
        public LocationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
            
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LocationEntry()
        {
            return View();    
        }
        [HttpPost]
        public async Task<IActionResult> LocationEntry(Location location)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(location), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"] + "Location/AddLocation";
                using (var response = await client.PostAsync(endpoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Location details saved succesfully";
                    }
                    else
                    {
                        ViewBag.staus = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }
    }
}
