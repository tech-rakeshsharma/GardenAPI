using GardenERP.Domain.Entities;
using GardenERP.Domain.Interfaces;
using GardenERP.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GardenERP.Application.Services;

namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserMasterService _service;

        private readonly ILogger<UserController> _logger;

        public UserController(UserMasterService userMasterService, ILogger<UserController> logger)
        {
            _service = userMasterService;
            _logger = logger;
        }

        //public UserController(UserMasterService userMasterService)
        //    => _service = userMasterService;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
            => Ok(await _service.GetAllUsers());

        public record LoginRequest(string UserName, string Password);
        public record LogoutRequest(string UserName);

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _service.Login(request.UserName, request.Password);
            if (user == null) return Unauthorized();
            return Ok(user);
        }
        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequest request)
        //{
        //    if (request is null || string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
        //    {
        //        _logger.LogWarning("Login called with invalid payload: {@Payload}", request);
        //        return BadRequest("Username and password are required.");
        //    }

        //    _logger.LogInformation("Login attempt for user {UserName}", request.UserName);

        //    var user = await _service.Login(request.UserName, request.Password);

        //    if (user == null)
        //    {
        //        _logger.LogInformation("Login failed for user {UserName}", request.UserName);
        //        return Unauthorized();
        //    }

        //    _logger.LogInformation("Login succeeded for user {UserName}", request.UserName);
        //    return Ok(user);
        //}

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            await _service.Logout(request.UserName);
            return Ok();
        }
    }

    
}

