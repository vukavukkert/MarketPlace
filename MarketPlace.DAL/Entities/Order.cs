using System;
using System.Collections.Generic;

namespace MarketPlace.DAL.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int User { get; set; }

    public int PickupPoint { get; set; }

    public int Item { get; set; }

    public DateTime? OrderDate { get; set; }

    public virtual Item ItemNavigation { get; set; } = null!;

    public virtual PickupPoint PickupPointNavigation { get; set; } = null!;

    public virtual ICollection<PickupPointOrder> PickupPointOrders { get; set; } = new List<PickupPointOrder>();

    public virtual User UserNavigation { get; set; } = null!;
}
