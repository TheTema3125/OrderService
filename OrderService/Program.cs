using Microsoft.EntityFrameworkCore;
using OrderService.Classes;
using OrderService.Models;
using OrderService.Enum;

var builder = WebApplication.CreateBuilder(args);
string connection = "Server=DESKTOP-6CBMVSA\\SQLEXPRESS; Database=Orders; User Id=Service; Password=Service; TrustServerCertificate=True";

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/", async (ApplicationContext db) => await db.Orders.Include(o => o.Lines).ToListAsync());

app.MapPost("/orders", async (Order order, ApplicationContext db) =>
{
    order.Status = StatusOrder.New.ToString();
    order.Created = DateTime.Now;

    await db.Orders.AddAsync(order);
    await db.SaveChangesAsync();
    return order;
});

app.Run();