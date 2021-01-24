    internal void AddCrossReference(DocX doc, Paragraph p, string destination)
            {
                XNamespace ns= doc.Xml.Name.NamespaceName;
                XNamespace xmlSpace = doc.Xml.GetNamespaceOfPrefix("xml");
                p = p.Append(" (see pp");
                p.Xml.Add(new XElement(ns + "r", new XElement(ns + "fldChar", new XAttribute(ns + "fldCharType", "begin"))));
                p.Xml.Add(new XElement(ns + "r", new XElement(ns + "instrText", new XAttribute(xmlSpace + "space", "preserve"), String.Format(" PAGEREF {0} \\h ", destination))));
                p.Xml.Add(new XElement(ns + "r", new XElement(ns + "fldChar", new XAttribute(ns + "fldCharType", "separate"))));
                p.Xml.Add(new XElement(ns + "r", new XElement(ns + "rPr", new XElement(ns + "noProof")), new XElement(ns + "t", "1")));
                p.Xml.Add(new XElement(ns + "r", new XElement(ns + "fldChar", new XAttribute(ns + "fldCharType", "end"))));
                p = p.Append(")");
            }
