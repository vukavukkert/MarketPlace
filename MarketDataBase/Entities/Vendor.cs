namespace MarketDataBase.Entities;

public partial class Vendor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
