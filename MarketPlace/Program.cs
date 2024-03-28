using MarketDataBase.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var connectionString = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<MarketPlaceContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(connectionString);
});
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Index";
        options.AccessDeniedPath = "/Auth/Index";
    });
var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Market}/{action=Index}/{id?}");


app.Run();
