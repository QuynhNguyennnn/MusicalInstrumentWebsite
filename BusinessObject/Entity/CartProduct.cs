using System;
using System.Collections.Generic;

namespace BusinessObject.Entity;

public partial class CartProduct
{
    public int Id { get; set; }

    public int CartId { get; set; }

    public int ProductId { get; set; }

    public bool Status { get; set; }

    public virtual Cart Cart { get; set; }

    public virtual Product Product { get; set; }
}
