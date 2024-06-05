using Microsoft.AspNetCore.Mvc;
using Points_System.Models;
using Points_System.Services;
using System.Configuration;

namespace Points_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        CustomerServices xservices;

        public CustomerController(CustomerServices xservices)
        {
            this.xservices = xservices;
        }

        [HttpGet]
        public async Task<List<customers>> Customers()
        {
            var ret = await xservices.Customers();
            return ret;
        }

        [HttpGet]
        public async Task<List<customers>> SearchCustomer(string search)
        {
            var ret = await xservices.SearchCustomer(search);
            return ret;
        }

        [HttpPost]
        public async Task<int> AddCustomer([FromBody] customers cus)
        {
            var ret = await xservices.AddCustomer(cus);
            return ret;
        }

        [HttpPut]
        public async Task<int> UpdateCustomer([FromBody] customers cus)
        {
            var ret = await xservices.UpdateCustomer(cus);
            return ret;
        }
    }
}
