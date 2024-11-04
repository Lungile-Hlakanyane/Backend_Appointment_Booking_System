using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppointmentBookingSystem.Data;
using AppointmentBookingSystem.Models;
using AppointmentBookingSystem.DTO;
using AppointmentBookingSystem.Interface;

namespace AppointmentBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment(AppointmentDTO appointmentDTO)
        {
            var appointment = await _appointmentService.CreateAppointmentAsync(appointmentDTO);
            return CreatedAtAction(nameof(CreateAppointment), new { id = appointment.AppointmentId }, appointment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments(Guid userId)
        {
            var appointments = await _appointmentService.GetAppointmentsAsync(userId);
            return Ok(appointments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelAppointment(Guid id)
        {
            var result = await _appointmentService.CancelAppointmentAsync(id);
            return result ? Ok() : NotFound();
        }
    }

}
