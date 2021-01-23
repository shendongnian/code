    class Program
    {
        const string _kxmlInput =
            @"<parent1>
          <listchild>
               <child>
                   <listchild2>
                        <child/>
                        <child/>
                        <child/>
                   </listchild2>
               </child>
               <child>
                    <listchild2>
                         <child/>
                         <child/>
                         <child/>
                    </listchild2>
               </child>
          </listchild>
    </parent1>";
        static void Main(string[] args)
        {
            Console.WriteLine(removeParentNode(_kxmlInput));
        }
        static string removeParentNode(string xml)
        {
            StringReader reader = new StringReader(xml);
            XDocument xdoc = XDocument.Load(reader);
            //remove parent1 
            XDocument xdoc1 = new XDocument(KeepDescendants(xdoc.Root, "child"));
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            using (XmlWriter xmlWriter = XmlWriter.Create(sb, settings))
                xdoc1.WriteTo(xmlWriter);
            return sb.ToString();
        }
        private static XElement KeepDescendants(XElement node, string descendantName)
        {
            var child = node.Descendants(descendantName).Select(c => KeepDescendants(c, descendantName));
            if (!child.Any())
            {
                return node;
            }
            XElement newParent = new XElement(node.Name);
            newParent.Add(child);
            return newParent;
        }
    }
