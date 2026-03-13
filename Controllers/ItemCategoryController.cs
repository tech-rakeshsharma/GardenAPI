using GardenERP.Application.DTOs.ItemCategory;
using GardenERP.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryService _itemCategoryService;

      
        public ItemCategoryController(IItemCategoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }

     
        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateItemCategoryDto dto)
        {
            var id = await _itemCategoryService.CreateAsync(dto);
            return Ok(new { ItemCategoryId = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _itemCategoryService.GetAllAsync();
            return Ok(data);
        }

  
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _itemCategoryService.GetByIdAsync(id);
            return Ok(data);
        }

    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _itemCategoryService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}