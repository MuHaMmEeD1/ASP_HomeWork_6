using ASP_HomeWork_6.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HomeWork_6.Entities.Concrete
{
    public class CartLine
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
