using Microsoft.AspNetCore.Mvc;
using Points_System.Models;
using Points_System.Services;

namespace Points_System.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : Controller
    {
        OrderServices xservices;

        public OrderController(OrderServices xservices)
        {
            this.xservices = xservices;
        }

        [HttpGet]
        public async Task<List<orders>> Orders()
        {
            var ret = await xservices.Orders();
            return ret;
        }

        [HttpGet]
        public async Task<List<orders>> SearchOrder(string search)
        {
            var ret = await xservices.SearchOrder(search);
            return ret;
        }

        [HttpPost]
        public async Task<int> AddOrder([FromBody] order2 _order)
        {
            var ret = await xservices.AddOrder(_order);
            return ret;
        }
        [HttpPost]
        public async Task<int> AddOrder2([FromBody] order2 _order)
        {
            var ret = await xservices.AddOrder2(_order);
            return ret;
        }
    }
}
