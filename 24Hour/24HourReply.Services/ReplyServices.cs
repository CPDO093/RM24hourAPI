using _24HourReply.Data;
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
                ctx.Reply.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Reply
                                .Where(e => e.OwnerId == _authorId)
                                .Select(e => new ReplyListItem()
                                {
                                    ReplyId = e.ReplyId,
                                    RText = e.Rtext,
                                    CreatedUtc = e.CreatedUtc
                                });
                return query.ToArray();
            }
        }
        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Reply
                                .Single(e => e.ReplyId == id && e.OwnerId == _authorId);
                return
                    new ReplyDetail()
                    {
                        ReplyId = entity.ReplyId,
                        RText = entity.RText,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Reply
                                .Single(e => e.ReplyId == model.ReplyId && e.OwnerId == _authorId);
                entity.RText = model.RText;
                entity.ModifiedUtc = model.ModifiedUtc;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
