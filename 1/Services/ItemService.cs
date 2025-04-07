namespace WebApplication1.Services
{
    using Microsoft.Extensions.Caching.Memory;
    using WebApplication1.Interfaces;
    using WebApplication1.Models;

    public class ItemService : IItemService
    {
        private readonly IMemoryCache _cache;
        private const string CacheKey = "ItemsList";

        public ItemService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void AddItemsToCache(List<Item> items)
        {
            _cache.Set(CacheKey, items);
        }

        public List<Item> GetItemsFromCache()
        {
            return _cache.TryGetValue(CacheKey, out List<Item> items) ? items : new List<Item>();
        }

        public List<Item> GetItemsByPage(int pageIndex, int pageSize)
        {
            var items = GetItemsFromCache();
            return items.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public List<Item> FilterItemsByTypeAndYear(string type, int minYear)
        {
            var items = GetItemsFromCache();
            return items.Where(item => item.Type == type && item.CreateYear >= minYear).ToList();
        }
    }

}
