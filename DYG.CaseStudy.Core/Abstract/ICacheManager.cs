using System;

namespace DYG.CaseStudy.Core.Abstract
{
    public interface ICacheManager
    {
        void CacheItem(string key, object item, DateTimeOffset offset);
        object GetCacheItem(string key);
        void RemoveCache(string key);
        object GetSingleCacheItem(string key, string id);
    }
}
