using GardenERP.Application;
using GardenERP.Application.Interface;
using GardenERP.Application.Services;
using GardenERP.Domain.Interfaces;
using GardenERP.Infrastructure;
using GardenERP.Infrastructure.Data;
using GardenERP.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using QuizServer.Models;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<GardenDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
// ================= UNIT OF WORK =================
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// ================= REPOSITORIES =================
//builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
//builder.Services.AddScoped<IPurchaseDetailRepository, PurchaseDetailRepository>();
//builder.Services.AddScoped<IStockLedgerRepository, StockLedgerRepository>();
//builder.Services.AddScoped<IItemRepository, IItemRepository>();
//builder.Services.AddScoped<ISupplierRepository, ISupplierRepository>();
//builder.Services.AddScoped<IBranchRepository, IBranchRepository>();

// ================= SERVICES =================
//builder.Services.AddScoped<IPurchaseService, PurchaseService>();
//builder.Services.AddScoped<IItemService, IItemService>();
//builder.Services.AddScoped<ISupplierService, ISupplierService>();
//builder.Services.AddScoped<IBranchService, IBranchService>();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowQuizApp",
//        policy =>
//        {
//            policy.WithOrigins("https://api.perfectitspot.com")
//                  .AllowAnyHeader()
//                  .AllowAnyMethod()
//                  .AllowCredentials();
//        });
//});
// CORS: allow Angular dev server (adjust origins as needed)
//var angularDevOrigins = new[] { "http://localhost:4200", "https://localhost:4200" };
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngularDev", policy =>
//    {
//        policy.WithOrigins(angularDevOrigins)
//              .AllowAnyHeader()
//              .AllowAnyMethod()
//              .AllowCredentials();
//    });
//});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<IUserMasterRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS policy before routing/authorization
app.UseCors("AllowAll");
//app.UseCors("AllowQuizApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
