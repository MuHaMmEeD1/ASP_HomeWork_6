using ASP_HomeWork_6.Entities.Concrete;
using ASP_HomeWork_6.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HomeWork_6.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Product product);
        List<CartLine> List(Cart cart);
        void RemoveFromCart(Cart cart, int productId);
    }
}
