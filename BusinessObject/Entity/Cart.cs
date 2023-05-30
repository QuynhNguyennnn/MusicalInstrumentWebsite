using System;
using System.Collections.Generic;

namespace BusinessObject.Entity;

public partial class Cart
{
    public int CartId { get; set; }

    public int CustomerId { get; set; }

    public int Quantity { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    public virtual Customer Customer { get; set; }
}
