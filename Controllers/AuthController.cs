using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_API.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var respone = await _authRepo.Register(
                new User { UserName = request.UserName }, request.Password
            );
            if(!respone.Success) {
                return BadRequest(respone);
            }
            return Ok(respone);
        }

          [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserRegisterDto request)
        {
            var respone = await _authRepo.Login(request.UserName, request.Password);
            if(!respone.Success) {
                return BadRequest(respone);
            }
            return Ok(respone);
        }
    }
}