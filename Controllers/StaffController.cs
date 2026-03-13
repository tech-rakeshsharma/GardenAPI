using GardenERP.Application.DTOs.Staff;
using GardenERP.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateStaffDto dto)
        {
            var id = await _staffService.CreateAsync(dto);
            return Ok(new { StaffId = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _staffService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _staffService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _staffService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}