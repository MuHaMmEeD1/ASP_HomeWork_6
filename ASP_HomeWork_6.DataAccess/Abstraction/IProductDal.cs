using ASP_HomeWork_6.Core.DataAccess;
using ASP_HomeWork_6.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HomeWork_6.DataAccess.Abstraction
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
