using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Collections.Generic;
using System.Globalization;

namespace WebApplication1
{
    public class DataGenerator
    {
        private List<List<string>> ParseCsv(byte[] input, char delimiter = ',')
        {
            using (var ms = new MemoryStream(input))
            using (var csv = new LumenWorks.Framework.IO.Csv.CsvReader(new StreamReader(ms), false, delimiter))
            {
                var output = new List<List<string>>();
                while (csv.ReadNextRecord())
                {
                    var row = new List<string>();
                    for (int i = 0; i < csv.FieldCount; i++)
                    {
                        row.Add(csv[i]);
                    }

                    output.Add(row);
                }

                return output;
            }
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var csvTable = new System.Data.DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead("./output.csv")), true))
            {
                csvTable.Load(csvReader);
            }

            var rows = csvTable.Rows;
            List<Event> events = new List<Event>();

            using (var context = new DatabaseContext(
    serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {
                int i = 99;

                foreach (System.Data.DataRow row in rows)
                {

                    var culture = new CultureInfo("en-US");
                    events.Add(
                    new Event
                    {
                        Id = ++i,
                        Name = row.ItemArray[0].ToString(),
                        Date = Convert.ToDateTime(row.ItemArray[1]),
                        Category = new Category
                        {
                            Id = ++i,
                            Name = row.ItemArray[4].ToString()
                        },
                        Organizer = new Organizer
                        {
                            Id = ++i,
                            Name = row.ItemArray[4].ToString()
                        },
                        Longitude = decimal.Parse(row.ItemArray[7].ToString(), culture),
                        Latitude = decimal.Parse(row.ItemArray[6].ToString(), culture)
                    });
                    
                    //Longitude = Convert.ToDecimal(row.ItemArray[6].ToString()),
                    //Latitude = Convert.ToDecimal(row.ItemArray[7].ToString())
                };
                // Look for any board games.
                context.Events.AddRange(events);
                context.SaveChanges();
                                if (context.Events.Any())
                {
                    return;   // Data was already seeded
                }
            }

        }

    }
    //for (int i = 0; i < values.Length - 1; i += 8)
    //{
    //    new Event
    //    {
    //        Id = i,
    //        Organizer = new Organizer
    //        {
    //            Id = i,
    //            Name = values[i % 8];
    //        },
    //        Category = new Category
    //        {
    //            Id = 1,
    //            Name = values[(i + 1) % 8];
    //        },
    //        Content = values[(i+2)%8],
    //        Date = values[(i + 3) % 8],
    //        ParticipantsCount = values[(i + 4) % 8],
    //        Price = values[(i + 5) % 8],
    //        TicketsLink = values[(i + 6) % 8],
    //        Duration = values[(i + 7) % 8],
    //        Longitude = values[(i + 8) % 8],
    //        Latitude = values[(i + 9) % 8]
    //    }

    
    //}
    //}
}


//context.Events.AddRange(
//                    new Event
//                    {
//                     Id   = 1,
//                     Organizer = new Organizer
//                     {
//                         Id = 1,
//                         Name = "Organizator"
//                     },
//                     Category = new Category
//                     {
//                         Id = 1,
//                         Name = "Category"
//                     },
//                     Content = "Opis iwentu",
//                     Date = DateTime.Now,
//                     ParticipantsCount = 10,
//                     Price = 0,
//                     TicketsLink = "www.urllink.com",
//                     Duration = 120,
//                     Longitude = 20,
//                     Latitude = 30
//                    },
//                    new Event
//                    {
//                        Id = 2,
//                        OrganizerId = 1,
//                        CategoryId = 1,
//                        Content = "Opis iwentu 2",
//                        Date = DateTime.Now,
//                        ParticipantsCount = 20,
//                        Price = 0,
//                        TicketsLink = "www.urllink2.com",
//                        Duration = 122,
//                        Longitude = 30,
//                        Latitude = 40
//                    }
//                );


//            }
//        }


