using Device_and_Its_Brands.Data;
using Device_and_Its_Brands.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Device_and_Its_Brands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Productx.Include(x => x.Category).OrderBy(x => x.Name).ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }




        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Result = _context.Productx.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
                return Ok(Result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }




        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            try
            {
                if (model != null)
                {
                    _context.Productx.Add(model);
                    _context.SaveChanges();
                    return Ok(model);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product model)
        {
            try
            {
                var Result = _context.Productx.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    Result.CategoryId = model.CategoryId;
                    Result.Name = model.Name;
                    Result.Quntity = model.Quntity;
                    Result.Price = model.Price;
                    Result.Descount = model.Descount;
                    Result.Total = model.Total;

                    _context.Productx.Update(Result);
                    _context.SaveChanges();
                    return Ok(Result);
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Result = _context.Productx.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    _context.Productx.Remove(Result);
                    _context.SaveChanges();
                    return Ok();
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
    }
}