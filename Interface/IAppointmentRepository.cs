using AppointmentBookingSystem.Models;

namespace AppointmentBookingSystem.Interface
{
    public interface IAppointmentRepository
    {
        Task<Appointment> AddAppointmentAsync(Appointment appointment);
        Task<IEnumerable<Appointment>> GetAppointmentsByUserIdAsync(Guid userId);
        Task<bool> DeleteAppointmentAsync(Guid appointmentId);
    }
}
