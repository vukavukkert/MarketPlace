﻿using System;
using System.Collections.Generic;

namespace MarketDataBase.Entities;

public partial class PickupPoint
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public string? Picture { get; set; }

    public decimal? Rating { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<PickupPointOrder> PickupPointOrders { get; set; } = new List<PickupPointOrder>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
