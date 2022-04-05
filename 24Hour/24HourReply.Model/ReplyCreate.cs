﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//comment so git thinks this is different
namespace _24HourReply.Model
{
    internal class ReplyCreate
    {
        [Required]
        [MinLength(2, ErrorMessage="Not enough characters for a reply!")]
        [MaxLength(250, ErrorMessage ="No one will read this, to many characters for a reply!")]
        public string RText { get; set; }
    }
}
