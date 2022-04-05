using _24HourComment.Model;
using RM24HourAPI.Models;
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

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new CommentCreate()
                {
                    AuthorId = _userId,
                    CommentId = model.CommentId,
                    CommentText = model.CommentText,
                    CreatedUtc = model.CreatedUtc
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            CommentId = e.CommentId,
                            CommentText = e.CommentText,
                            CreatedUtc = e.CreatedUtc

                        }
                        );

                return query.ToArray();
            }
        }

        public CommentItem GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id && e.AuthorId == _userId);
                return
                    new CommentItem
                    {
                        CommentId = entity.CommentId,
                        CommentText = entity.CommentText,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }

        public bool DeleteComment(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == postId && e.AuthorId == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveCommentChanges() == 1;
            }
        }
    }
}
