using System;
using System.Collections.Generic;

namespace BusinessObject.Entity;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public string CustomerType { get; set; }

    public double AccumulatedPoint { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
