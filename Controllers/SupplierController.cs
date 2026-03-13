using GardenERP.Application.DTOs.Supplier;  
using GardenERP.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

    
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

  
        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateSupplierDto dto)
        {
            var id = await _supplierService.CreateAsync(dto);
            return Ok(new { SupplierId = id });
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _supplierService.GetAllAsync();
            return Ok(data);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _supplierService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _supplierService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}