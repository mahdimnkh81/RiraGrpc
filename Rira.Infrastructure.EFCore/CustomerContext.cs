using Microsoft.EntityFrameworkCore;
using Rira.Domain.CustomerAgg;
using Rira.Infrastructure.EFCore.Mapping;

namespace Rira.Infrastructure.EFCore
{
    public class CustomerContext : DbContext
    {
        DbSet<Customer> _customerSet { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMapping());
            //var assembly = typeof(CustomerMapping).Assembly;
            //modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
