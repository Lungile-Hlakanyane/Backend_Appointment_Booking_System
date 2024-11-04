using AppointmentBookingSystem.Data;
using AppointmentBookingSystem.Interface;
using AppointmentBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBookingSystem.Implementation
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly BookingContext _context;

        public AppointmentRepository(BookingContext context)
        {
            _context = context;
        }

        public async Task<Appointment> AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByUserIdAsync(Guid userId)
        {
            return await _context.Appointments.Where(a => a.UserId == userId).ToListAsync();
        }



        public async Task<bool> DeleteAppointmentAsync(Guid appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment == null) return false;
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
