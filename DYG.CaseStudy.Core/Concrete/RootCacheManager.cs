using DYG.CaseStudy.Core.Abstract;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace DYG.CaseStudy.Core.Concrete
{
    public class RootCacheManager : ICacheManager
    {
        private readonly IMemoryCache memoryCache;

        public RootCacheManager(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        public void CacheItem(string key, object item, DateTimeOffset offset)
        {
            memoryCache.Set(key, item, offset);
           
        }
        public object GetCacheItem(string key)
        {
           return  memoryCache.Get(key);
        }

        public object GetSingleCacheItem(string key, string id)
        {
            return memoryCache.TryGetValue("haberler", out id);
        }

        public void RemoveCache(string key)
        {
            throw new NotImplementedException();
        }
    }
}
