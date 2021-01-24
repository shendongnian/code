    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load("test.xml");
            var replacements = doc.Descendants()
                .Select(GetReplacementForParent)
                .Where(r => r != null)
                .ToList();
            foreach (var replacement in replacements)
            {
                replacement.Parent.ReplaceWith(replacement);
            }
            Console.WriteLine(doc);
        }
        
        static XElement GetReplacementForParent(XElement element)
        {
            var child = element.Elements(element.Name).FirstOrDefault();
            // TODO: Use a more efficient approach for counting children, maybe.
            // TODO: Check for non-element content? Check for attributes?
            return child != null && element.Elements().Count() == 1
                ? child : null;
        }
    }
