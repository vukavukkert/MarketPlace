namespace MarketDataBase.Entities;

public partial class Item
{
    public int Id { get; set; }

    public int Amount { get; set; }

    public decimal Price { get; set; }

    public decimal? Rating { get; set; }

    public string? Picture { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Vendor { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Vendor VendorNavigation { get; set; } = null!;
}
