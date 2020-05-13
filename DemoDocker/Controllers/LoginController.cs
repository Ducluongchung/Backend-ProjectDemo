using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoDocker.Domain.Dtos.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public string username = "digimed";
        public string password = "123456";

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = new LoginRequest(username, password);
            if (request.userName != user.userName)
            {
                return BadRequest("Account not found");
            }
            else if (request.passWord != user.passWord)
            {
                return BadRequest("Password is incorect");
            }
            else
                return Ok();
        }
    }
}