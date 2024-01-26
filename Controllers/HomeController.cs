﻿using System.Diagnostics;
using API_Usage_Fix.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API_Usage_Fix.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
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