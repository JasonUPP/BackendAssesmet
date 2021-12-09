using Assesmet.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesmet.Context
{
    public class AtosContext : DbContext
    {
        public AtosContext(DbContextOptions<AtosContext> options) : base(options)
        { }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Countries> Countries { get; set; }
    }
}
