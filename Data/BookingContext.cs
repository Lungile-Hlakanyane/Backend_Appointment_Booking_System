using AppointmentBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBookingSystem.Data
{
    public class BookingContext :DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Additional configuration for User or Appointment entities can go here
        }
    }
}
