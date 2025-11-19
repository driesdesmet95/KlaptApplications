using Klapt.Event.Domain.EventDateEntity;
using Klapt.Event.Domain.EventEntity;
using Microsoft.EntityFrameworkCore;

namespace Klapt.Event.EfCore
{
    public class KlaptEventDbContext : DbContext
    {
        private readonly string _connectionString;

        // Optional: accept connection string via constructor
        public KlaptEventDbContext()
        {
           _connectionString = "Server=LPT80627\\SQLADVODATA1;Database=KlaptEventDb;User Id=sa;Password=dRPCYesxGDuWrY00waLa;TrustServerCertificate=True;";
        }

        public KlaptEventDbContext(DbContextOptions<KlaptEventDbContext> options)
            : base(options) { }

        public DbSet<EventItem> EventItems => Set<EventItem>();
        public DbSet<EventDate> EventDates => Set<EventDate>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use your connection string here
                optionsBuilder.UseSqlServer(_connectionString
                    ?? "Server=.;Database=KlaptEventDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEventItem(modelBuilder);
            ConfigureEventDate(modelBuilder);
        }

        private static void ConfigureEventItem(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<EventItem>();
            entity.HasMany(e => e.Dates)
                  .WithOne(d => d.Event)
                  .HasForeignKey(d => d.EventId)
                  .IsRequired();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
        }

        private static void ConfigureEventDate(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<EventDate>();
            entity.Property(d => d.Start).IsRequired();
            entity.Property(d => d.End).IsRequired();
            entity.HasIndex(d => d.Start);
            entity.HasIndex(d => d.End);
        }
    }
}
