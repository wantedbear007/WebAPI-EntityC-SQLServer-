


using Microsoft.EntityFrameworkCore;
using Vehicle.Data;
using Vehicle.IControllers;
using Vehicle.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VehicleDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICar, CarRepository>();
builder.Services.AddScoped<IOwner, OwnerRepository>();
// builder.Services.AddScoped<IMaintenanceRecord, MaintenanceRecordRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();