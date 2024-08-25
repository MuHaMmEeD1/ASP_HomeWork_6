using ASP_HomeWork_6.Business.Abstract;
using ASP_HomeWork_6.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_HomeWork_6.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult> Index(int page = 1, int category = 0, int sort = 0)
        {
            var items = await _productService.GetAllByCategoryAsync(category);
            int pageSize = 10;

            var model = new ProductListViweModel
            {
                Products = sort == 0 ? items.Skip((page - 1) * pageSize).Take(pageSize).ToList()
                : sort == 1 ? items.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(pr => pr.ProductName).ToList()
                : sort == 2 ? items.Skip((page - 1) * pageSize).Take(pageSize).OrderByDescending(pr => pr.ProductName).ToList()
                : sort == 3 ? items.Skip((page - 1) * pageSize).Take(pageSize).OrderBy(pr => pr.UnitPrice).ToList()
                : sort == 4 ? items.Skip((page - 1) * pageSize).Take(pageSize).OrderByDescending(pr => pr.UnitPrice).ToList()
                : []
                ,
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page,
                PageCount = (int)Math.Ceiling(items.Count / (double)pageSize),
                CurrentSort = sort
                
            };
            return View(model);
        }
    }
}
