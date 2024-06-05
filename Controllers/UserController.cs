﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Points_System.Models;
using Points_System.Services;

namespace Points_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        UserServices xservices;

        public UserController(UserServices xservices)
        {
            this.xservices = xservices;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<users>> Login(string username, string password)
        {
            var ret = await xservices.Login(username, password);
            return ret;
        }
    }
}
