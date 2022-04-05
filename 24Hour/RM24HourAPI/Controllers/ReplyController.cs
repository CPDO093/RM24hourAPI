using _24HourReply.Model;
using _24HourReply.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RM24HourAPI.Controllers
{
    [Authorize]
    public class ReplyController : ApiController
    {
        private ReplyServices CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId);
            var replyService = new ReplyServices(userId);
            return replyService;
        }
        public IHttpActionResult Get()
        {
            ReplyServices replyServices = CreateReplyService();
            var reply = replyServices.GetReply();
            return Ok(reply);
        }
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.CreateReply(reply))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            ReplyServices replyService = CreateReplyService();
            var reply = replyService.GetReplyById(id);
            return Ok();
        }
        public IHttpActionResult Put(ReplyEdit reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.UpdateReply(reply))
                return InternalServerError();

            return Ok();
        }

    }

}
