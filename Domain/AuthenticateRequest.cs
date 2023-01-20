﻿using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class AuthenticateRequest
    {
        //[Required]
        //public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
