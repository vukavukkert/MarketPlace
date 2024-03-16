using MarketDataBase.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var connectionString = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<MarketPlaceContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Market}/{action=Index}/{id?}");


app.Run();
