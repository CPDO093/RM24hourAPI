using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourComment.Data
{
    internal class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public Guid AuthorId { get; set; }

    }
}
