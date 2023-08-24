using Demo.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                //Checking if database exists or not
                return NotFound("Database not found!");
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


        [HttpGet, Route("/GetAllStudent")]
        public IActionResult GetAll()
        {
            if (_context.CrudEntity == null)
            {
                //Checking if database exists or not
                return NotFound("Database not found!");
            }
            try
            {
               // _context.CrudEntity.Add(student);
                //_context.SaveChanges();
                return Ok(_context.CrudEntity.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet, Route("/GetStudent/{id}")]
        public IActionResult GetStudent(String id)
        {
            if (_context.CrudEntity == null)
            {
                //Checking if database exists or not
                return NotFound("Database not found!");
            }
            try
            {
               var student=_context.CrudEntity.Find(id);
                if(student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpDelete, Route("/DeleteStudent/{id}")]
        public IActionResult DeleteStudent(String id)
        {
            if (_context.CrudEntity == null)
            {
                //Checking if database exists or not
                return NotFound("Database not found!");
            }
            try
            {
               var student=_context.CrudEntity.Find(id);
                if(student == null)
                {
                    return NotFound() ;
                }
                _context.CrudEntity.Remove(student);
                _context.SaveChanges();
                return StatusCode(200, new JsonResult("Student data deleted"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPut, Route("/PutStudent/{id}")]
        public IActionResult PutStudent(String id,CrudEntity student)
        {
            if (_context.CrudEntity == null)
            {
                //Checking if database exists or not
                return NotFound("Database not found!");
            }
            try
            {
               if(id != student.Username)
               {
                    return BadRequest();
               }
               if(!crudExist(id))
                {
                    return NotFound();
                }
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok("Successfully updated");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        private bool crudExist(string id)
        {
            return (_context.CrudEntity?.Any(e => e.Username == id)).GetValueOrDefault();
        }

    }
}