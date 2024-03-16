using System.ComponentModel.DataAnnotations;

namespace MarketDataBase.Entities;

public partial class Item
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Amount is required")]
    public int Amount { get; set; }
    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }

    public decimal? Rating { get; set; }

    public string? Picture { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Description is required")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Vendor is required")]
    public int Vendor { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Vendor VendorNavigation { get; set; } = null!;
}
