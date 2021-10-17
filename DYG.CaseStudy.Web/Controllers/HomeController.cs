using DYG.CaseStudy.Core.Abstract;
using DYG.CaseStudy.Core.Entities;
using DYG.CaseStudy.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DYG.CaseStudy.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICacheManager cacheManager;

        public HomeController(ILogger<HomeController> logger, ICacheManager cacheManager)
        {

            _logger = logger;
            this.cacheManager = cacheManager;

        }

        public IActionResult Index()
        {
            var newsList = new List<Root>();
            var file = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{"Data\\case_study.data.json"}");
            var JSON = System.IO.File.ReadAllText(file);
            var jsonData = JsonConvert.DeserializeObject<List<JsonData>>(JSON);
            cacheManager.CacheItem("haberler", jsonData, DateTimeOffset.MaxValue);
            return RedirectToAction("NewsList");
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
        [HttpGet]
        public IActionResult NewsList()
        {
            var jsonData = cacheManager.GetCacheItem("haberler");
            if (jsonData == null)
            {
                return RedirectToAction("Index");
            }

            return View(jsonData);
        }

        [HttpGet()]
        public IActionResult NewsByCategory(string id)
        {
            var newsList = cacheManager.GetCacheItem("haberler");

            if (newsList == null)
            {
                return RedirectToAction("Index");
            }

            var list = (List<JsonData>)newsList; 
            var item = list.FindAll(x => x.MainCategory.Slug == id);

            return View(item);
        }


        [HttpGet()]
        public IActionResult GetNewsDetail(string id)
        {
            var list = (List<JsonData>)cacheManager.GetCacheItem("haberler");
            if (list == null)
            {
                return RedirectToAction("Index");
            }
            var item = list.FirstOrDefault(x => x.Root.Id == Guid.Parse(id));
            return View(item);
        }

    }
}
