    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace SortXml
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(INPUT_FILENAME);
                XmlSort xmlSort = new XmlSort();
                xmlSort.SortXml(doc);
                doc.Save(OUTPUT_FILENAME);
            }
        }
        public class XmlSort : IComparer<XElement>
        {
            public void SortXml(XDocument doc)
            {
                RecursiveSort(doc.Root);
            }
            public void RecursiveSort(XElement elements)
            {
                foreach (XElement element in elements.Elements())
                {
                    RecursiveSort(element);
                }
                List<XElement> children = elements.Elements().AsEnumerable().ToList();
                if (children.Count > 1)
                {
                    children.Sort(new XmlSort());
                    elements.ReplaceWith(new XElement(elements.Name.LocalName, children));
                }
            }
            public int Compare(XElement a, XElement b)
            {
                
                string attributesA = string.Join("^", a.Attributes().Select(x => string.Join("^",x.Name.LocalName + (string)x))); 
                string hashA = string.Join("^", new string[] {a.Name.LocalName, attributesA, (string)(XElement)a.NextNode});
                string attributesB = string.Join("^", b.Attributes().Select(x => string.Join("^", x.Name.LocalName + (string)x)));
                string hashB = string.Join("^", new string[] { b.Name.LocalName, attributesB, (string)(XElement)b.NextNode });
                int results = hashA.CompareTo(hashB);
                return results;
            }
        }
    }
