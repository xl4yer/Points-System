using Microsoft.AspNetCore.Mvc;
using Points_System.Models;
using Points_System.Services;

namespace Points_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : Controller
    {
        ItemServices xservices;

        public ItemController(ItemServices xservices)
        {
            this.xservices = xservices;
        }

        [HttpGet]
        public async Task<List<items>> Items()
        {
            var ret = await xservices.Items();
            return ret;
        }

        [HttpGet]
        public async Task<List<items>> SearchItem(string search)
        {
            var ret = await xservices.SearchItems(search);
            return ret;
        }

        [HttpPost]
        public async Task<int> AddItem([FromBody] items i)
        {
            var ret = await xservices.AddItems(i);
            return ret;
        }

        [HttpPut]
        public async Task<int> UpdateItem([FromBody] items i)
        {
            var ret = await xservices.UpdateItems(i);
            return ret;
        }
    }
}
