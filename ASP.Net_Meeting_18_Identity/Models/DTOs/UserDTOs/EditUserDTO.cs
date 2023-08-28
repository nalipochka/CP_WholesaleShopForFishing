﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP.Net_Meeting_18_Identity.Models.DTOs.UserDTOs
{
    public class EditUserDTO
    {
        [Required]
        public string Id { get; set; } = default!;

        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; } = default!;

        [Required]
        [Display(Name = "Year of birth")]
        public int YearOfBirth { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;
    }
}
