using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public interface IDatabaseContext
    {
         DbSet<Event> Events { get; set; }
         DbSet<Organizer> Organizers { get; set; }
         DbSet<Category> Categories { get; set; }
    }
}
