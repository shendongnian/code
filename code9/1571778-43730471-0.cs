    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    namespace LinqToXmlExample
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                XElement root = XElement.Load("[your file path here]");
                XName[] names = new XName[] { "firstChild", "secondChild", "thirdChild" };
                IEnumerable<XElement> elements =
                    names.AsParallel()
                         .Select(
                             name =>
                                 new XElement(
                                     $"result_{name}",
                                     root.Descendants(name)
                                         .AsParallel()
                                         .Select(
                                            x => new XElement(name, x.Attributes()))))
                         .ToArray();
            }
        }
    }
