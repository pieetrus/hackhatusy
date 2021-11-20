using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Organizer Organizer { get; set; }
        public int OrganizerId { get; set; }
        public string Content { get; set; }
        public int ParticipantsCount { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string TicketsLink { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
