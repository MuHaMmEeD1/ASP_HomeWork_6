using ASP_HomeWork_6.Entities.Models;

namespace ASP_HomeWork_6.WebUI.Models
{
    public class AdminCategoryListViewModel
    {
        public string Name { get; set; }
        public List<Category>? Categories { get; set; }
        public int CurrentCategory { get; set; }
    }
}
