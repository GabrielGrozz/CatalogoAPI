using Microsoft.AspNetCore.Mvc;

namespace Projeto_ApiCatalogo.Controllers
{
      
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
