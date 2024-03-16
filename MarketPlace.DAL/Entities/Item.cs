using System.ComponentModel;

namespace MarketPlace.DAL.Entities;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [DisplayName("Vendor")]
    public int Vendor { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Vendor VendorNavigation { get; set; } = null!;
}
