﻿using System;
using System.Collections.Generic;

namespace T2207A_API.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public string? Avatar { get; set; }

    public string? Password { get; set; }

    public string? Tel { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
