using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Poke_CRUD_App.Classes;
using Poke_CRUD_App.Models;

namespace Poke_CRUD_App.Controllers {
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

        // Get LoginPage - renders the login form page
        [HttpGet]
        [Route("Login")]
        public IActionResult LoginPage() {
            LoginRegisterViewModel pageModel = new LoginRegisterViewModel("LoginTry", "RegisterPage", "Login", "New user? Create an account", "Login");
            return View("LoginRegisterPage", pageModel);
        }

        // Get RegisterPage - renders the register form page
        [HttpGet]
        [Route("Register")]
        public IActionResult RegisterPage() {
            LoginRegisterViewModel pageModel = new LoginRegisterViewModel("RegisterTry", "LoginPage", "Register", "Existing user? Login here", "Register");
            return View("LoginRegisterPage", pageModel);
        }

        [HttpPost]
        public IActionResult LoginTry(IFormCollection formData) {
            UsersLoginService.CheckUserLogin(_appDbContext, formData["email"], formData["password"]);

            return View("Index");
        }

        [HttpPost]
        public IActionResult RegisterTry(IFormCollection formData) {
            UsersLoginService.RegisterUser(_appDbContext, formData["email"], formData["password"]);
            return View("Index");
        }


        // Get API_Call - Renders api call search page
        [HttpGet]
        [Route("Search")]
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

        [Route("Privacy")]
        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}