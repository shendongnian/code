    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Net;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<User> users =  doc.Descendants("User").Select(x => new User() {
                    userID = (string)x.Element("Username"),
                    pass = (string)x.Element("PasswordHash"),
                    banned = (bool)x.Element("Banned"),
                    lastIp = Dns.GetHostAddresses((string)(x.Element("LastLoginIP"))).FirstOrDefault(),
                    currentJob = x.Elements("CurrentJob").Select(y => new Job()
                    {
                        name = (string)y.Element("name")
                    }).FirstOrDefault(),
                    admin = (bool)x.Element("Admin")
                }).ToList();
            }
        }
        public class User
        {
            public string userID { get; set; }
            public string pass { get; set; }
            public bool banned { get; set; }
            public bool online;
            public IPAddress lastIp { get; set; }
            public bool admin { get; set; }
            public Job currentJob { get; set; } //another class just like the user class. the job will be loaded just like the users - from xml.
        }
        public class Job
        {
            public string name { get; set; }
        }
    }
