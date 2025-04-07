namespace WebApplication1.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WebApplication1.Interfaces;
    using WebApplication1.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public IActionResult AddItems(List<Item> items)
        {
            _itemService.AddItemsToCache(items);
            return Ok("Items added to cache.");
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _itemService.GetItemsFromCache();
            return Ok(items);
        }

        [HttpGet("page")]
        public IActionResult GetItemsByPage(int pageIndex, int pageSize)
        {
            var items = _itemService.GetItemsByPage(pageIndex, pageSize);
            return Ok(items);
        }

        [HttpGet("filter")]
        public IActionResult GetFilteredItems(string type, int minYear)
        {
            var filteredItems = _itemService.FilterItemsByTypeAndYear(type, minYear);
            return Ok(filteredItems);
        }
    }

}
