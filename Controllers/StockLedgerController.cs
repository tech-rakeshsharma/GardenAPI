using GardenERP.Application.DTOs;
using GardenERP.Application.DTOs.StockLedger;
using GardenERP.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockLedgerController : ControllerBase
    {
        private readonly IStockLedgerService _stockLedgerService;

        public StockLedgerController(IStockLedgerService stockLedgerService)
        {
            _stockLedgerService = stockLedgerService;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateStockLedgerDto dto)
        {
            var id = await _stockLedgerService.CreateAsync(dto);
            return Ok(new { StockLedgerId = id });
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _stockLedgerService.GetAllAsync();
            return Ok(data);
        }

        // GET BY ID
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var data = await _stockLedgerService.GetByIdAsync(id);
        //    return Ok(data);
        //}

        //// DELETE
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _stockLedgerService.DeleteAsync(id);
        //    return Ok("Deleted Successfully");
        //}
    }
}