            XmlNamespaceManager ns = new XmlNamespaceManager(new NameTable());
            ns.AddNamespace("xsl", "http://www.w3.org/1999/XSL/Transform");
            XmlParserContext parserContext = new XmlParserContext(null, ns, null, XmlSpace.None);
            XmlTextReader reader = new XmlTextReader(template, XmlNodeType.Element, parserContext);
            var element = XElement.Load(reader);
            xsl.Root.Element("Placeholder").ReplaceWith(element);
