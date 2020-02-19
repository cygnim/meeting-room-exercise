using Meetings.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Meetings.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : ControllerBase
    {
        // Get a single meeting plus it's associated room information and the list of invited users by the meeting id.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeeting(int id)
        {
            throw new NotImplementedException();
        }

        // Create a new meeting with a room and a list of attendees and return the room information
        public async Task<IActionResult> CreateMeeting()
        {
            throw new NotImplementedException();
        }

        // Delete an existing meeting and it's associated attendee list
        public async Task<IActionResult> DeleteMeeting()
        {
            throw new NotImplementedException();
        }
    }
}