    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        public class History
        {
            public string Name { get; set; }
            public string Number { get; set; }
            public List<Item> Items { get; set; }
    
        }
    
        public class Item
        {
            public DateTime? CreateDate { get; set; }
            public string Type { get; set; }
            public string Description { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string xmlString =
                    @"<Message>
                        <Header>..</Header>
                        <Body>
                            <History 
                                xmlns=""http://schemas.somewhere.com/types/history"">
                                <Number>12</Number>
                                <Name>History Name</Name>
                                <Item>
                                    <CreateDate></CreateDate>
                                    <Type>Item 1 Type</Type>
                                    <Description>Item 1 Description</Description>
                                </Item>
                                <Item>
                                    <CreateDate></CreateDate>
                                    <Type>Item 2 Type</Type>
                                    <Description>Item 2 Description 1</Description>
                                    <Description>Item 2 Description 2</Description>
                                </Item>
                            </History>
                        </Body>
                    </Message>";
    
    
                XNamespace ns = "http://schemas.somewhere.com/types/history";
                var xElement = XDocument.Parse(xmlString);
    
                var historyObject = xElement.Descendants(ns +"History")
                    .Select(historyElement => new History
                    {
                        Name = historyElement.Element(ns + "Name")?.Value,
                        Number = historyElement.Element(ns + "Number")?.Value,
                        Items = historyElement.Elements(ns + "Item").Select(x => new Item()
                        {
                            CreateDate = DateTime.Parse(x.Element(ns + "CreateDate")?.Value),
                            Type = x.Element(ns + "Type")?.Value,
                            Description = string.Join(",", x.Elements(ns + "Description").Select(elem=>elem.Value))
                        }).ToList()
                    }).FirstOrDefault();
            }
        }
    }
