using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourComment.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public virtual List<Reply> Replies { get; set; }
        //[Required]
        //foreign key via Id for virtual post
    }
}
