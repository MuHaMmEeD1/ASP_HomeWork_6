using ASP_HomeWork_6.Business.Abstract;
using ASP_HomeWork_6.DataAccess.Abstraction;
using ASP_HomeWork_6.DataAccess.Concrete.EFEntityFramework;
using ASP_HomeWork_6.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HomeWork_6.Business.Concrete
{
    public class CatagoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CatagoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryDal.GetList();
        }

        public async Task AddAsync(Category product)
        {
            await _categoryDal.Add(product);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _categoryDal.Get(p => p.CategoryId == id);
            await _categoryDal.Delete(item);
        }


    }
}
