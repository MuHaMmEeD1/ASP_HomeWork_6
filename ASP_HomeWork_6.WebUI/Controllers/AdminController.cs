using ASP_HomeWork_6.Business.Abstract;
using ASP_HomeWork_6.Entities.Models;
using ASP_HomeWork_6.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_HomeWork_6.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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



        public async Task<ActionResult> Delete(int id, int page = 1, int category = 0, int sort = 0)
        {

            await _productService.DeleteAsync(id); // Forgne Kek Qoymur Silmege

            return RedirectToAction("Index", new {page= page, category=category, sort=sort});
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Add(ProductViewModel pr)
        {


            Product product = new Product
            {
            
                ProductName = pr.ProductName,
                SupplierId = pr.SupplierId,
                CategoryId = pr.CategoryId,
                QuantityPerUnit = pr.QuantityPerUnit,
                UnitPrice = pr.UnitPrice,
                UnitsInStock = pr.UnitsInStock,
                UnitsOnOrder = pr.UnitsOnOrder,
                ReorderLevel = pr.ReorderLevel,
                Discontinued = pr.Discontinued,


            };

            await _productService.AddAsync(product);

            return RedirectToAction("Index", "Admin");
        }


        public async Task<ActionResult> DeleteCategory(int id)
        {

            await _categoryService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> AddCategory(AdminCategoryListViewModel adminCategoryListView)
        {

            Category ct = new Category { 

                CategoryName = adminCategoryListView.Name,
                Description = "", 
                Picture = new byte[] { 0xFF, 0xD8, 0xFF },
                


            };

            await _categoryService.AddAsync(ct);

            return RedirectToAction(nameof(Index));
        }





    }
}
