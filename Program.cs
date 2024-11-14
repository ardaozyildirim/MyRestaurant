using Microsoft.EntityFrameworkCore;
using MyRestaurant.Busınnes.Servıces.Abstract;
using MyRestaurant.Busınnes.Servıces.Concrete;
using MyRestaurantApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantısını ayarlayın
builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger ve diğer servisleri ekleyin
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryServıce, CategoryServıce>();

var app = builder.Build();

// Swagger'ı geliştirme ortamında etkinleştirin
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
