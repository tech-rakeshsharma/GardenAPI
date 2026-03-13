using GardenERP.Application.DTOs;
using GardenERP.Application.DTOs.branch;
using GardenERP.Application.Interface;
using Microsoft.AspNetCore.Mvc;
namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(CreateBranchDto dto)
        {
            var id = await _branchService.CreateAsync(dto);
            return Ok(new { BranchId = id });
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _branchService.GetAllAsync();
            return Ok(data);
        }

        // GET BY ID
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var data = await _branchService.GetByIdAsync(id);
        //    return Ok(data);
        //}

        //// DELETE
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _branchService.DeleteAsync(id);
        //    return Ok("Deleted Successfully");
        //}
    }
}
