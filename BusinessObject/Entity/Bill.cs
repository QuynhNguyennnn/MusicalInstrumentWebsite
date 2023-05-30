using System;
using System.Collections.Generic;

namespace BusinessObject.Entity;

public partial class Bill
{
    public int BillId { get; set; }

    public int StaffId { get; set; }

    public int CustomerId { get; set; }

    public DateTime PurchaseDate { get; set; }

    public double Total { get; set; }

    public bool State { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<BillProduct> BillProducts { get; set; } = new List<BillProduct>();

    public virtual Customer Customer { get; set; }

    public virtual Staff Staff { get; set; }
}
