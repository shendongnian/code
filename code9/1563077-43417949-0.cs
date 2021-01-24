    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace LinqExample
    {
        class Program
        {
            public class Entity
            {
                public int Id { get; set; }
                public DateTime Date { get; set; }
            }
            static void Main(string[] args)
            {
                List<Entity> entities = new List<Entity>()
                {
                    new Entity() { Id = 1, Date = DateTime.Parse("2017-04-14 21:02:37")},
                    new Entity() { Id = 2, Date = DateTime.Parse("2017-04-14 21:03:42")},
                };
    
                var OccurencesPerDay = from entity in entities
                                       group entity by entity.Date.Date into g
                                       select new {Date = g.Key.Date, Occurences = g.Count()};
                // Above is more readable than, even though both are equal
                OccurencesPerDay = entities.
                    GroupBy(ent => ent.Date.Date).
                    Select(ents => new { Date = ents.Key.Date, Occurences = ents.Count()} );
    
    
    
                Console.WriteLine($"| Date | Occurences |");
                foreach (var occ in OccurencesPerDay)
                {
                    Console.WriteLine($"| {occ.Date} | {occ.Occurences} |");
                }
            }
        }
    }
