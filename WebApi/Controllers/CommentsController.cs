using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Contexts;
using WebApi.Models.Entities;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly SqlDataContext _context;

        public CommentsController(SqlDataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CommentRequest req)
        {
            try
            {
                var commentEntity = new CommentEntity
                {
                    Comment = req.Comment,
                    Created = DateTime.Now,
                    IssueId = req.IssueId,
                    CustomerId = req.CustomerId
                };
                _context.Add(commentEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(commentEntity);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

    }

}
