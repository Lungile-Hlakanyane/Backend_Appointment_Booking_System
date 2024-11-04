﻿using System.ComponentModel.DataAnnotations;

namespace AppointmentBookingSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
