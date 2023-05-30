using BusinessObject.Entity.Enum;
using System;
using System.Collections.Generic;

namespace BusinessObject.Entity;

public partial class Account
{
    public int Id { get; set; }

    public int PeopleId { get; set; }

    public Role Role { get; set; }

    public string Gmail { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public bool Status { get; set; }

    public virtual Customer People { get; set; }

    public virtual Staff PeopleNavigation { get; set; }
}
