using System.Diagnostics;
using API_Usage_Fix.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Usage_Fix.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult API_Call() {
            HttpClient httpClient = HttpClientHelper.GetHttpClientHelper();

            Task<HttpResponseMessage> apiResponse = httpClient.GetAsync("https://balldontlie.io/api/v1/players?search=giannis");
            Debug.WriteLine(apiResponse.Result.Content.ReadAsStringAsync().Result);

            return View("Index");
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}