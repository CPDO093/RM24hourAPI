using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourComment.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid UserID)
        {
            _userId = UserID;
        }


    }
}
