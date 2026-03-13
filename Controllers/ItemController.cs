using GardenERP.Application.DTOs.Item;
using GardenERP.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

    
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateItemDto dto)
        {
            var id = await _itemService.CreateAsync(dto);
            return Ok(new { ItemId = id });
        }

     
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _itemService.GetAllAsync();
            return Ok(data);
        }

   
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _itemService.GetByIdAsync(id);
            return Ok(data);
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _itemService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}