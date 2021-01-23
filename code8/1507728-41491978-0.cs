    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication34
    {
        class Program
        {
            static void Main(string[] args)
            {
                Customer customer = new Customer()
                {
                    Address = new Address()
                    {
                        city = "Chennai",
                        State = "tamilnadu",
                    },
                    user = new User()
                    {
                        Name = "test",
                        Id = "001",
                        response = new Dictionary<string, string>() {
                            { "response1", "response1"},
                            { "response2", "response2"}
                        }
                    }
                };
                XElement row = new XElement("row", new object[] {
                    new XElement("cell", new object[] {
                        new XAttribute("cellType", "city"),
                        customer.Address.city
                    }),
                    new XElement("cell", new object[] {
                            new XAttribute("cellType", "state"),
                            customer.Address.State
                        }),
                    new XElement("cell", new object[] {
                            new XAttribute("cellType", "name"),
                            customer.user.Name
                        }),
                    new XElement("cell", new object[] {
                            new XAttribute("cellType", "id"),
                            customer.user.Id
                        }),
                        customer.user.response.AsEnumerable().Select(x => new XElement("cell", new object[] {
                            new XAttribute("cellType",x.Key),
                            x.Value
                        }))
                });
     
             } 
            //<row>
            //    <cell cellType="city">Chennai</cell>
            //    <cell cellType="state">tamilnadu</cell>
            //    <cell cellType="name">test</cell>
            //    <cell cellType="id">001</cell>
            //    <cell cellType="response1">response1</cell>
            //    <cell cellType="response2">response2</cell>
            //</row>
        }
        public class Customer
        {
            public Address Address { get; set; }
            public User user { get; set; }
        }
        public class Address
        {
            public string city { get; set; }
            public string State { get; set; }
        }
        public class User
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public Dictionary<String, String> response { get; set; }
        }
     
    }
