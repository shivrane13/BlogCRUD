using BlogCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogCRUD.Data
{
    public class MyAppContext: DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options): base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Authour> Authours { get; set; }
    }
}
