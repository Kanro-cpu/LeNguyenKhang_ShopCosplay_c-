using LeNguyenKhang_2122110497.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Thêm DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Đăng ký Controller
builder.Services.AddControllers();

// 3. Đăng ký Swagger (Thay thế cho AddOpenApi)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Cấu hình giao diện Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Dòng này giúp hiện giao diện web để bạn test API
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();