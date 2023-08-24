using Demo.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController: ControllerBase
    {
        private readonly CrudDbContext _context;
        public CrudController(CrudDbContext context)
        {
            _context = context;
        }
        [HttpPost,Route("/RegisterStudent")]
        public IActionResult Add(CrudEntity student)
        {
            if(_context.CrudEntity==null)
            {
                return BadRequest("Database not found!");
            }
            try
            {               
                _context.CrudEntity.Add(student);
                _context.SaveChanges();
                return Ok("Student Added");
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}