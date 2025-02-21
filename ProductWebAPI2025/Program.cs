using Microsoft.EntityFrameworkCore;
using ProductModel;
using ClassS00219971.Data;

namespace ProductWebAPI2025
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register SQLite Database
            builder.Services.AddDbContext<ProductDBContext>(options =>
                options.UseSqlite("Data Source=../ProductModel/ProductCoreDB-2025.db"));
            
            // ✅ Register CustomerDbContext
            builder.Services.AddDbContext<CustomerDbContext>(options =>
                options.UseSqlite("Data Source=../ClassS00219971/CustomerCorDB-S00219971.db"));

            builder.Services.AddTransient<IProduct<Product>, ProductRepository>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}