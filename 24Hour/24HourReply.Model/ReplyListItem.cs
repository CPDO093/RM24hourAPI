using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourReply.Model
{
    internal class ReplyListItem
    {
        public int ReplyId { get; set; }
        
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
