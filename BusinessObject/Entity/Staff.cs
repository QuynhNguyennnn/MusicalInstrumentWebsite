using System;
using System.Collections.Generic;

namespace BusinessObject.Entity;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public string Image { get; set; }

    public bool State { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
