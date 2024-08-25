
using ASP_HomeWork_6.Core.Abstraction;
using System;
using System.Collections.Generic;

namespace ASP_HomeWork_6.Entities.Models;

public partial class Category : IEntity
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

