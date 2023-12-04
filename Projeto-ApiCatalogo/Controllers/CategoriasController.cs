using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_ApiCatalogo.Context;
using Projeto_ApiCatalogo.Models;
using System.Security.Cryptography.X509Certificates;

namespace Projeto_ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {

            return _context.Categories.ToList();
                        
        }

        [HttpGet("{id:int}", Name ="GetCategory")]
        public ActionResult<Category> Get(int id) 
        {
            Category categorie = _context.Categories.FirstOrDefault(e => e.CategoryId == id);

            if(categorie == null)
            {
                return NotFound();
            }

            return categorie;
        }

        [HttpPost]
        public ActionResult Post(Category categorie)
        {
            if(categorie == null)
            {
                return BadRequest();

            }
            _context.Categories.Add(categorie);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCategory", new { id = categorie.CategoryId }, categorie);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id ,Category categorie) 
        {
            if(id != categorie.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(categorie).State = EntityState.Modified;
            _context.SaveChanges(true);

            return Ok(categorie);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(e => e.ProductId == id);
            if(product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
    }
}
