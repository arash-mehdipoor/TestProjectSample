using Microsoft.AspNetCore.Mvc;
using WebAppMvc.Models.Entities;
using WebAppMvc.Models.Services;

namespace WebAppMvc.Controllers
{
    public class ProductController : Controller
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = _productService.Get(id);
            if (product is null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                _productService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                _productService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }
    }
}
