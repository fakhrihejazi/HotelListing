using HotelListing.Configurations;
using HotelListing.Data;
using HotelListing.IRepository;
using HotelListing.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add DB Context
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));



//Add Cors
builder.Services.AddCors(o => {
    o.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MapperInitilizer));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddSwaggerGen();

// Logger 
builder.Host.UseSerilog((ctx,lc)=>lc
    .WriteTo.Console()
    .WriteTo.File(path:"logs\\log-.txt",
                   outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.ff zzz} [{level:u3}] {Message:lj}{NewLine}{Exception}",
                   rollingInterval: RollingInterval.Day,
                   restrictedToMinimumLevel:Serilog.Events.LogEventLevel.Information));

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(op=>
            op.SerializerSettings.ReferenceLoopHandling=
            Newtonsoft.Json.ReferenceLoopHandling.Ignore);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app Cors
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
