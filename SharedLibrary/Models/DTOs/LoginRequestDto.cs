﻿using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models.DTOs
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
