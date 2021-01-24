    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication49
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                List<Entity> entities = new List<Entity>() {
                    new Entity() { Id = 1, Date = DateTime.Parse("2017-01-16 12:58:32")},
                    new Entity() { Id = 2, Date = DateTime.Parse("2017-01-16 11:36:01")},
                    new Entity() { Id = 3, Date = DateTime.Parse("2017-01-16 17:55:19")},
                    new Entity() { Id = 4, Date = DateTime.Parse("2017-01-19 13:19:40")},
                    new Entity() { Id = 5, Date = DateTime.Parse("2017-01-19 09:21:55")}
                };
                var results = entities.GroupBy(x => x.Date.Date).Select(x => new { count = x.Count(), entities = x.ToList() }).ToList();
            }
        }
        public class Entity
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
        }
    }
