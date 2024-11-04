using AppointmentBookingSystem.Models;

namespace AppointmentBookingSystem.Interface
{
    public interface IAppointmentService
    {
        Task<Appointment> CreateAppointmentAsync(DTO.AppointmentDTO appointmentDTO);
        Task<IEnumerable<Appointment>> GetAppointmentsAsync(Guid userId);
        Task<bool> CancelAppointmentAsync(Guid appointmentId);
    }
}
