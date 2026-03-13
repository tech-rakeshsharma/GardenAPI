using GardenERP.Application.DTOs.Customer;   
using GardenERP.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GardenServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

      
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

     
        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateCustomerDto dto)
        {
            var id = await _customerService.CreateAsync(dto);
            return Ok(new { CustomerId = id });
        }

     
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _customerService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _customerService.GetByIdAsync(id);
            return Ok(data);
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}