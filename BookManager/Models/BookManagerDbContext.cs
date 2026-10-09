using Microsoft.EntityFrameworkCore;
namespace BookManager.Models
{
    public class BookManagerDbContext: DbContext
    {
        public BookManagerDbContext(DbContextOptions<BookManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
