                XDocument doc = XDocument.Load(FILENAME);
                XElement node = doc.Root;
                XNamespace xNs = node.GetDefaultNamespace();
                XElement node2 = doc.Descendants().Where(x => x.Name.LocalName == "Node2").FirstOrDefault();
                XNamespace x2Ns = node2.GetDefaultNamespace();
