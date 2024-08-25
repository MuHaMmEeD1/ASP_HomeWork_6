using ASP_HomeWork_6.Entities.Models;

namespace ASP_HomeWork_6.WebUI.Models
{
    public class ProductListViweModel
    {
        public List<Product>? Products { get; set; }
        public int PageSize { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int PageCount { get; internal set; }
        public int CurrentPage { get; internal set; }
        public int CurrentSort { get; internal set; }
    }
}
