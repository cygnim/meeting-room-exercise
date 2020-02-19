using System.Collections;
using System.Collections.Generic;

namespace Meetings.Domain
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxOccupancy { get; set; }
        public List<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}