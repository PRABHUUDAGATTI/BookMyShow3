using Book_Show_Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMVC_UI.Controllers
{
    public class BookShowController : Controller
    {
        private IConfiguration _configuration;
        public BookShowController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BookShowEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookShowEntry(BookShow bookShow)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bookShow), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiBaseUrl"]+ "BookShow/AddBookShow";
                using (var response = await client.PostAsync(endpoint,content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie details saved succesfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }

            return View();
        }
    }
}
