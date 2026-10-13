using Microsoft.EntityFrameworkCore;
using BookManager.Models;
namespace BookManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BookManagerDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookManagerDBConnection")));

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            EnsureDatabase.Migrate(app);

            app.Run();
        }
    }
}
