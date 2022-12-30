using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MiniCloud.Middleware;
using MiniCloud.Service;
using Persistence;
using System.Configuration;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
//Инфраструктура
//builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddDbContext<UserDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(UserRepository<>));
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

//Кастомный jwt
app.UseCustomJwtMiddleware();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
