    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Request request = doc.Elements("EnvelopeStatus").Select(x => new  Request() {
                    Id = (string)x.Element("Id"),
                    Status = (string)x.Element("Status"),
                    Url = (string)x.Descendants("CustomField").Where(y => (string)y.Descendants("Name").FirstOrDefault() == "Url").Select(z => z.Element("Value")).FirstOrDefault(),
                    ItemId = (int)x.Descendants("CustomField").Where(y => (string)y.Descendants("Name").FirstOrDefault() == "ItemId").Select(z => z.Element("Value")).FirstOrDefault(),
                    List = (string)x.Descendants("CustomField").Where(y => (string)y.Descendants("Name").FirstOrDefault() == "List").Select(z => z.Element("Value")).FirstOrDefault(),
                    Signers = x.Descendants("RecipientStatus").Select(y => new Signer() {
                        Type = (string)y.Descendants("Type").FirstOrDefault(),
                        Email = (string)y.Descendants("Email").FirstOrDefault(),
                        UserName = (string)y.Descendants("UserName").FirstOrDefault(),
                        UserId = (int)y.Descendants("CustomField").FirstOrDefault()
                    }).ToList()
                }).FirstOrDefault();
            }
        }
        public class Request
        {
            public string Id { get; set; }
            public string Status { get; set; }
            public string Url { get; set; }
            public string List { get; set; }
            public int ItemId { get; set; }
            public List<Signer> Signers { get; set; }
        }
        public class Signer
        {
            public string Type { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public int UserId { get; set; }
        }
    }
