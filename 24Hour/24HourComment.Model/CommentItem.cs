using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourComment.Model
{
    public class CommentItem
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public Guid AuthorId { get; set; }

        [Display(Name="Time Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
