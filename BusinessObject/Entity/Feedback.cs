using System;
using System.Collections.Generic;

namespace BusinessObject.Entity;

public partial class Feedback
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public string Comment { get; set; }

    public int Range { get; set; }

    public bool Status { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual Product Product { get; set; }
}
