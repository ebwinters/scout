using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Scout.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Scout.Infrastructure.Contexts
{
    public class ScoutContext : DbContext
    {
        public ScoutContext()
        {
        }

        public ScoutContext(DbContextOptions<ScoutContext> options) : base(options) { }

        public DbSet<ScoutEntity> Scouts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultContainer("scouts");
            builder.Entity<ScoutEntity>().ToContainer("scouts");
            builder.Entity<ScoutEntity>()
            .HasPartitionKey(x => x.scoutId);

        }
    }
}
