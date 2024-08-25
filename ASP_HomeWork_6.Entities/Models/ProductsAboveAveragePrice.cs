using System;
using System.Collections.Generic;

namespace ASP_HomeWork_6.Entities.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
