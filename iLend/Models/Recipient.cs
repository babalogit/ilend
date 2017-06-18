﻿using System;
using System.ComponentModel.DataAnnotations;

namespace iLend.Models
{
    public class Recipient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Min18YearsToRegister]
        public DateTime BirthDate { get; set; }

        public bool IsSubscibedToNewsletter { get; set; }

        public UserGroup UserGroup { get; set; }

        [Display(Name = "User Group")]
        public byte UserGroupId { get; set; }
    }
}