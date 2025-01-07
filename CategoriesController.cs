using Device_and_Its_Brands.Data;
using Device_and_Its_Brands.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Device_and_Its_Brands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var Resutl = _context.Categorx.OrderBy(x => x.Name).ToList();
                return Ok(Resutl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_context.Categorx.FirstOrDefault(x => x.Id == id));

            }

            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Save")]
        public IActionResult Save([FromBody] Category model)
        {
            try
            {
                _context.Categorx.Add(model);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Edit/{id}")]
        public IActionResult Edit(int id, [FromBody] Category model)
        {
            try
            {
                var Result = _context.Categorx.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    Result.Name = model.Name;
                    _context.Update(Result);
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

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var Result = _context.Categorx.FirstOrDefault(x => x.Id == id);
                if (Result != null)
                {
                    _context.Categorx.Remove(Result);
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
    }
}