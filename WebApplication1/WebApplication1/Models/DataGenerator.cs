using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                // Look for any board games.
                if (context.Events.Any())
                {
                    return;   // Data was already seeded
                }

                context.Events.AddRange(
                    new Event
                    {
                     Id   = 1,
                     Organizer = new Organizer
                     {
                         Id = 1,
                         Name = "Organizator"
                     },
                     Category = new Category
                     {
                         Id = 1,
                         Name = "Category"
                     },
                     Content = "Opis iwentu",
                     Date = DateTime.Now,
                     ParticipantsCount = 10,
                     Price = 0,
                     TicketsLink = "www.urllink.com",
                     Timestamp = 120
                    },
                    new Event
                    {
                        Id = 2,
                        OrganizerId = 1,
                        CategoryId = 1,
                        Content = "Opis iwentu 2",
                        Date = DateTime.Now,
                        ParticipantsCount = 20,
                        Price = 0,
                        TicketsLink = "www.urllink2.com",
                        Timestamp = 122
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
