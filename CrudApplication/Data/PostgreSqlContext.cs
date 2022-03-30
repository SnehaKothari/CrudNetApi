using LinqToDB.SchemaProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using user.Web.Models;
using user.Web.Repository;
using user.Web.Data;

namespace user.Web.Data
{
    public class PostgreSqlContext:DbContext

    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Users> users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
