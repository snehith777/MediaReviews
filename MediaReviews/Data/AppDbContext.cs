using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MediaReviews.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Review> Reviews { get; set; }
    }

}
