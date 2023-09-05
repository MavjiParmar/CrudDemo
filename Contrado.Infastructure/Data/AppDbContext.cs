using Contrado.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Contrado.Infastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.HasDefaultSchema("dbo");
      


            // ----- End for sales return -----

            foreach (var foreignkeys in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignkeys.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // dynamically load all configurations
            IEnumerable<Type> typeConfigurations = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.GetInterfaces().Any(m => m.GetTypeInfo().IsGenericType && m.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (Type typeConfiguration in typeConfigurations)
            {
                dynamic configurationInstance = Activator.CreateInstance(typeConfiguration);
                builder.ApplyConfiguration(configurationInstance);
            }

            base.OnModelCreating(builder);
        }

        //public DbSet<RoleMenuPermission> RoleMenuPermission { get; set; }


        public override int SaveChanges()
        {
            AddBaseEntityInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddBaseEntityInfo();
            return await base.SaveChangesAsync();
        }

        private void AddBaseEntityInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added
                        && ((BaseEntity)entry.Entity).CreatedDate == DateTime.MinValue)
                {
                    ((BaseEntity)entry.Entity).CreatedDate = DateTime.UtcNow;
                    
                }
            }
        }
    }
}
