using AppointmentBookingSystem.DTO;
using AppointmentBookingSystem.Interface;
using AppointmentBookingSystem.Models;

namespace AppointmentBookingSystem.Implementation
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> CreateAppointmentAsync(AppointmentDTO appointmentDTO)
        {
            var appointment = new Appointment
            {
                Date = appointmentDTO.Date,
                Time = appointmentDTO.Time,
                Description = appointmentDTO.Description,
                UserId = appointmentDTO.UserId
            };
            return await _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync(Guid userId)
        {
            return await _appointmentRepository.GetAppointmentsByUserIdAsync(userId);
        }

        public async Task<bool> CancelAppointmentAsync(Guid appointmentId)
        {
            return await _appointmentRepository.DeleteAppointmentAsync(appointmentId);
        }
    }
}
