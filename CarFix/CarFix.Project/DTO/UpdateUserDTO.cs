﻿using CarFix.Project.Enum;
using System;

namespace CarFix.Project.DTO
{
    public class UpdateUserDTO
    {
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public EnUserType? UserType { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
