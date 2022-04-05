using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourComment.Model
{
    public class CommentCreate
    {
        [Required]
        public int CommentId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [MinLength(2,ErrorMessage ="Please enter at least 2 characters.")]
        [MaxLength(300,ErrorMessage ="Please limit your comment to 300 characters.")]
        public string CommentText { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public virtual List<Reply> Replies { get; set; }

    }
}
