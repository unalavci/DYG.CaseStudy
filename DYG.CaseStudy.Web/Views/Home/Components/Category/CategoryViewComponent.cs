using DYG.CaseStudy.Core.Abstract;
using DYG.CaseStudy.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DYG.CaseStudy.Web.Views.Home.Components.Category
{
    public class CategoryViewComponent :ViewComponent
    {
        private readonly ICacheManager cacheManager;

        public CategoryViewComponent(ICacheManager cacheManager)
        {
            this.cacheManager = cacheManager;
        }
        public IViewComponentResult Invoke()
        {
            var categories = cacheManager.GetCacheItem("haberler");

            return View("CategoryViewComponent", categories);
        }
    }
}
