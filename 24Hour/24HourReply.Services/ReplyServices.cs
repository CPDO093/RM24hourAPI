using _24HourReply.Model;
using RM24HourAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourReply.Services
{
    public  class ReplyServices
    {
        private readonly Guid _authorId;
        public ReplyServices(Guid userId)
        {
            _authorId = userId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                OwnerId = _authorId,
                RText = model.RText,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Note.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
