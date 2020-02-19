using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Meetings.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        public RoomsController()
        {
        }

        // Get a room by it's Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        // Returns a list of rooms that are available between the specified start and end date
        [HttpGet("date")]
        public async Task<IActionResult> GetRoomByDateRange(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
    }
}
