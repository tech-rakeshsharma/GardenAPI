using GardenERP.Application.DTOs.Purchase;   
using GardenERP.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

  
        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

  
        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdatePurchaseDto dto)
        {
            var id = await _purchaseService.CreateAsync(dto);
            return Ok(new { PurchaseId = id });
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _purchaseService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _purchaseService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _purchaseService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}