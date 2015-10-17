using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Vandring.Models;

namespace Vandring.ModelContexts
{
    public class ModelContext : IdentityDbContext<User>
    {
        public DbSet<World> Worlds { get; set; }
        public DbSet<WorldMembership> WorldMemberships { get; set; }

        public ModelContext()
            : base("Vandring")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorldMembership>().Property(t => t.UserId).IsRequired();
        }
    }
}
