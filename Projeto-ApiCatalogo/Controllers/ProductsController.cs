using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_ApiCatalogo.Context;
using Projeto_ApiCatalogo.Models;
using System.Security.Cryptography.X509Certificates;

namespace Projeto_ApiCatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {

            try
            {
                throw new Exception("FAIO");
            }
            catch(Exception ex) { }
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "excessão no banco de dados");
            }

            //var products = _context.Products.AsNoTracking().ToList();
            //if(products is null) 
            //{
            //    return NotFound("nao encontrado");
            //}

            //return products;
        }

        [HttpGet("{id:int}", Name ="GetProduct")]
        public ActionResult<Product> Get(int id) 
        {
            var product = _context.Products.AsNoTracking().FirstOrDefault(e => e.ProductId == id);
            if(product is null)
            {
                return NotFound("Registro não encontrado");
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            if(product is null)
            {
                return BadRequest();
            }
            _context.Products.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetProduct",new { id =product.ProductId }, product);

        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(e => e.CategoryId == id);

            if (product is null)
            {
                return NotFound() ;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }

    }
}
