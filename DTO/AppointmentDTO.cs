using System.ComponentModel.DataAnnotations;

namespace AppointmentBookingSystem.DTO
{
    public class AppointmentDTO
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
