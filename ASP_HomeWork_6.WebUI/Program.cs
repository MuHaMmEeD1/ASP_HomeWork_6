using ASP_HomeWork_6.Business.Abstract;
using ASP_HomeWork_6.Business.Concrete;
using ASP_HomeWork_6.DataAccess.Abstraction;
using ASP_HomeWork_6.DataAccess.Concrete.EFEntityFramework;
using ASP_HomeWork_6.Entities.Models;
using ASP_HomeWork_6.WebUI.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IProductDal, EFProductDal>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryDal, EFCaregoryDal>();
builder.Services.AddScoped<ICategoryService, CatagoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartSessionService, CartSessionService>();


builder.Services.AddSession();


var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<NorthwindContext>(option =>
{
    option.UseSqlServer(connection);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
