    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace Oppgave3Lesson1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Context orgContext = new Context();
                DateTime today = DateTime.Now;
            
                var contacts = from c in orgContext.CreateQuery<Contact>()
                               //remoived value
                               where (c.BirthDate != null && c.BirthDate.Month == today.Month)
                               where (c.BirthDate != null && c.BirthDate.Day == today.Day)
                               select new { c.Id, c.LogicalName, c.BirthDate, c.FullName };
            }
        }
        public class Context
        {
            public List<Contact> CreateQuery<Contact>()
            {
                return new List<Contact>
            }
        }
        public class Contact
        {
            public DateTime BirthDate { get; set; }
            public int Id { get; set; }
            public string LogicalName { get; set; }
            public string FullName { get; set; }
        }
     
    }
