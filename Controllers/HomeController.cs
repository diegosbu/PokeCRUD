using System.Diagnostics;
using Poke_CRUD_App.Classes;
using Poke_CRUD_App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Poke_CRUD_App.Controllers
{
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext) {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult Login_Register() {
            return View("UserLoginRegister");
        }

        [HttpPost]
        public IActionResult LoginTry(IFormCollection formData) {
            UserLoginRegister.CheckUser(_appDbContext, formData["email"], formData["password"]);

            return View("Index");
        }


        // Get API_Call - Renders api call search page
        [HttpGet]
        public IActionResult API_Call() {
            return View("API Call");
        }


        // Post API_Call - Returns results of pokemon api search if applicable
        [HttpPost]
        public IActionResult API_Call(IFormCollection formData) {
            if (string.IsNullOrEmpty(formData["pokeName"])) {
                return View("API Call");
            } else {
                HttpClient httpClient = HttpClientHelper.GetHttpClientHelper();

                Task<HttpResponseMessage> apiResponse = httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{formData["pokeName"]}");

                string rawJsonStr = apiResponse.Result.Content.ReadAsStringAsync().Result;

                if (String.Equals(rawJsonStr, "Not Found", StringComparison.OrdinalIgnoreCase)) {
                    return View("API Call");
                } else {
                    Debug.WriteLine(rawJsonStr);

                    var pokemonJson = JObject.Parse(rawJsonStr);

                    ApiCallViewModel pokeModel = new ApiCallViewModel(pokemonJson["name"].ToString(), pokemonJson["sprites"]["front_default"].ToString());

                    return View("API Call", pokeModel);
                }
            }

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