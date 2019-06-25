using System;
using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EFCore.Data
{
    public class SamuraiContext : DbContext
    {
        public static readonly LoggerFactory loggerFactory
            = new LoggerFactory(new [] {
              new ConsoleLoggerProvider((category, level)
              => category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information, true) });

        public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
        {

        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlite(
                "/Users/Milind/Documents/Sources/C#/EntityFrameworkCore/Samurai.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.SamuraiId, s.BattleId });
        }
    }
}
