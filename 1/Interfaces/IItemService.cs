using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IItemService
    {
        void AddItemsToCache(List<Item> items);
        List<Item> GetItemsFromCache();
        List<Item> GetItemsByPage(int pageIndex, int pageSize);
        List<Item> FilterItemsByTypeAndYear(string type, int minYear);
    }

}
