using GardenERP.Application.DTOs.PurchaseDetail;  
using GardenERP.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseDetailController : ControllerBase
    {
        private readonly IPurchaseDetailService _purchaseDetailService;


        public PurchaseDetailController(IPurchaseDetailService purchaseDetailService)
        {
            _purchaseDetailService = purchaseDetailService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdatePurchaseDetailDto dto)
        {
            var id = await _purchaseDetailService.CreateAsync(dto);
            return Ok(new { PurchaseDetailId = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _purchaseDetailService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _purchaseDetailService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _purchaseDetailService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}