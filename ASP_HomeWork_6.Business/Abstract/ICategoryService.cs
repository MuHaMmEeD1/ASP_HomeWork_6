using ASP_HomeWork_6.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HomeWork_6.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task AddAsync(Category product);
        Task DeleteAsync(int id);
    }

}
