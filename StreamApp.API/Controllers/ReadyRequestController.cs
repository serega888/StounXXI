using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamApp.API.Data;
using StreamApp.API.Models;

namespace StreamApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadyRequestController : ControllerBase
    {
        private readonly DataContext _context;
        public ReadyRequestController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
       //   [HttpGet]
        public async Task<IActionResult> GetRequest(string name) {
            var valutes =  await _context.MyValutes.Join(_context.KursValutes,
            p => p.KursValuteId,
            c => c.Id,
            (p,c) => new {
                Name = p.Name,
                DateKurs = c.DateKurs,
                ValueKurs = p.ValueKurs
                
            }
            ).FirstOrDefaultAsync(x => x.Name == name);
            return Ok(valutes);
        }
    }
}