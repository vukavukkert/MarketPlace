using System;
using System.Collections.Generic;

namespace MarketPlace.DAL.Entities;

public partial class Staff
{
    public int Id { get; set; }

    public int User { get; set; }

    public int PickupPoint { get; set; }

    public virtual PickupPoint PickupPointNavigation { get; set; } = null!;

    public virtual ICollection<PickupPointOrder> PickupPointOrders { get; set; } = new List<PickupPointOrder>();

    public virtual User UserNavigation { get; set; } = null!;
}
