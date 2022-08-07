using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TripReport.Data.Models;

namespace TripReport.Data
{
    public class TripDbContext : IdentityDbContext<User>
    {
        public TripDbContext(DbContextOptions<TripDbContext> options)
            : base(options)
        {
        }
        public DbSet<Trip> Trip { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Duration> Duration { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Trip>()
                .HasOne(c => c.Payment)
                .WithMany(c => c.Trip)
                .HasForeignKey(c => c.PaymentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Trip>()
                .HasOne(c => c.Duration)
                .WithMany(c => c.Trip)
                .HasForeignKey(c => c.DurationId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }
    }
}