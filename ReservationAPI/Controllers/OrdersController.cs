using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Data.Interfaces;
using ReservationAPI.Models.ModelsDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _repo;

        public OrdersController(IOrderRepo repo)
        {
            _repo = repo;
        }
        
        // GET: api/<OrdersController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.Get());
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var res = _repo.Get(id);
                if (res == null)
                {
                    return NotFound($"No order found with ID = {id}");
                }
                return Ok(res);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post(OrderCreateDTO value)
        {
            try
            {
                _repo.Create(value);
                return Ok("Order Created Successfully"); 
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, OrderCreateDTO value)
        {
            try
            {
                _repo.Update(id, value);
                return Ok("Order Updated Successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok("Order Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
