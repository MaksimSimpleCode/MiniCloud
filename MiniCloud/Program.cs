using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MiniCloud.Middleware;
using MiniCloud.Service;
using Persistence;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using MiniCloud.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
        .WithOrigins("https://localhost:44451")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});
builder.Services.AddControllersWithViews();

//Инфраструктура
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddScoped(typeof(IRepository<>), typeof(UserRepository<>));
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

//Решает проблему при сохранении дат
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseDeveloperExceptionPage();




//Кастомный jwt
app.UseCustomJwtMiddleware();


//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
