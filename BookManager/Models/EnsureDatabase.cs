using Microsoft.EntityFrameworkCore;
namespace BookManager.Models
{
    public class EnsureDatabase
    {
        public static void Migrate(IApplicationBuilder app)
        {
            var ctx = app.ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<BookManagerDbContext>();

            if (ctx.Database.GetPendingMigrations().Any())
            {
                ctx.Database.Migrate();
            }
        }
    }
}
