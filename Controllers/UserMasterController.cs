
using GardenERP.Application.DTOs.UserMaster;
using GardenERP.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        private readonly IUserMasterService _userMasterService;

        public UserMasterController(IUserMasterService userMasterService)
        {
            _userMasterService = userMasterService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateUserMasterDto dto)
        {
            var id = await _userMasterService.CreateAsync(dto);
            return Ok(new { UserId = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _userMasterService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _userMasterService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userMasterService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}