using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApi.Contexts;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly SqlDataContext _context;

        public StatusesController(SqlDataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(StatusRequest req)
        {
            try
            {
                if(!await _context.Statuses.AnyAsync(x => x.Status == req.Status)) 
                { 
                    var statusEntity = new StatusEntity { Status = req.Status };
                    _context.Add(statusEntity);
                    await _context.SaveChangesAsync();

                    return new OkObjectResult(statusEntity);
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var statuses = new List<StatusModel>();
                foreach(var status in await _context.Statuses.ToListAsync())
                    statuses.Add(new StatusModel { Id = status.Id, Status =status.Status });

                return new OkObjectResult(statuses);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
        
    }
}
