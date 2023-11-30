using Microsoft.AspNetCore.Mvc;
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
            var products = _context.Products.ToList();

            if(products is null) 
            {
                return NotFound();
            }

            return products;
        }

        [HttpGet("{id:int}", Name ="GetProduct")]
        public ActionResult<Product> Get(int id) 
        {
            var product = _context.Products.FirstOrDefault(e => e.ProductId == id);
            if(product is null)
            {
                return NotFound("Registro não encontrado");
            }
            return product;
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
    }
}
