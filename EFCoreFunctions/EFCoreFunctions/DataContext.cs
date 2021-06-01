using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;

namespace EFCoreFunctions
{
    public class DataContext : DbContext
    {
        public DbSet<AuditLog> AuditLogs { get; set; }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EFCoreFunctions;User=sa;Password=Your_password123;MultipleActiveResultSets=true", options =>
            {
                options.MigrationsAssembly(this.GetType().Assembly.FullName);
            });
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DatabaseFunctions.Configure(modelBuilder);
        }
    }
}