using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using shopping.client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace shopping.client.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
        }

       // public async Task<IActionResult> Index()
        //{
          //  var options = new RestClientOptions("http://localhost:5000")
            //{
              //  MaxTimeout = -1,
            //};
            //var client = new RestClient(options);
            //var request = new RestRequest("/product", Method.Get);
            //RestResponse response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);
            //var response = await _httpClient.GetAsync("/product");
            //var content = await response.Content.ReadAsStringAsync();
          //  var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(response);

           // return View(response);
       // }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/product");
            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);

            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
