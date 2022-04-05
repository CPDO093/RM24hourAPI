using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourReply.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        [Required]
        public string RText { get; set; }
        public Guid OwnerId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
