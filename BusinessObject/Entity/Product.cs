using BusinessObject.Entity.Enum;
using System;
using System.Collections.Generic;

namespace BusinessObject.Entity;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public string Material { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public int YearOfManufacturer { get; set; }

    public string Description { get; set; }

    public string Image { get; set; }

    public int StaffId { get; set; }

    public bool Status { get; set; }

    public Categories Category { get; set; }

    public virtual ICollection<BillProduct> BillProducts { get; set; } = new List<BillProduct>();

    public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
