using ASP_HomeWork_6.Core.DataAccess.EntityFrameWork;
using ASP_HomeWork_6.DataAccess.Abstraction;
using ASP_HomeWork_6.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HomeWork_6.DataAccess.Concrete.EFEntityFramework
{
    public class EFProductDal : EFEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public EFProductDal(NorthwindContext context) : base(context)
        {
        }
    }
}
