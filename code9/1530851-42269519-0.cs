    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {    
        static void Main()
        {
            var element = new XElement(
                "root",
                new XElement("parent", new XElement("child")),
                new XElement("parent", new XElement("child"))
            );
            var children = element.Descendants("child");
            foreach (var child in children.ToList())
            {
                child.Parent.ReplaceWith(child);
            }
        }
    }
