using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Data.Interfaces;
using ReservationAPI.Models;
using ReservationAPI.Models.ModelsDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemRepo _menuItemRepo;

        public MenuItemsController(IMenuItemRepo repo)
        {
            _menuItemRepo = repo;
        }

        // GET: api/<MenuItemsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_menuItemRepo.Get());
        }

        // GET api/<MenuItemsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            

            try
            {
                MenuItemReadDTO res = _menuItemRepo.Get(id);

                if(res == null)
                {
                    return NotFound($"There is no Menu Item with ID = {id}");
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            
        }

        // POST api/<MenuItemsController>
        [HttpPost]
        public IActionResult Post(MenuItemCreateDTO value)
        {
            try
            {
                _menuItemRepo.Create(value);
                return Ok("Menu Item Added Successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT api/<MenuItemsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, MenuItemCreateDTO value)
        {
            try
            {
                _menuItemRepo.Update(id, value);
                return Ok("Menu Item Updated Successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<MenuItemsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _menuItemRepo.Delete(id);
                return Ok("Menu Item Deleted Successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
