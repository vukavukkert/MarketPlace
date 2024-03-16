using MarketPlace.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<MarketPlaceContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Market}/{action=Index}/{id?}");


app.Run();
