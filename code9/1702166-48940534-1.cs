        private void Run()
        {
            XDocument doc1 = XDocument.Load("xml1.xml");
            XDocument doc2 = XDocument.Load("xml2.xml");
            var id = @"urn:uuid:d0686356-19c7-4bf4-b915-db778c308d1c";
            ReplaceId(doc1, id, "new path");
            ReplaceId(doc2, id, "new path");
            doc1.Save("xml1_new.xml");
            doc2.Save("xml2_new.xml");
            Console.WriteLine("Enter to exit...");
            Console.ReadLine();
        }
        private void ReplaceId(XDocument doc, string id, string newValue)
        {
            var ns = doc.Root.GetDefaultNamespace();
            var assetElements = doc.Descendants(ns + "Asset");
            foreach (var element in assetElements)
            {
                var idElement = element.Descendants(ns + "Id").First();
                if (!idElement.Value.Equals(id))
                    continue;
                // for xml model #1
                SetNewValue(element, ns + "Path", newValue);
                // for xml model #2
                SetNewValue(element, ns + "OriginalFileName", newValue);
            }
        }
        private void SetNewValue(XElement currentElement, XName elementName, string newValue)
        {
            var matchingElements = currentElement.Descendants(elementName);
            if (matchingElements.Any())
            {
                foreach (var element in matchingElements)
                    element.SetValue(newValue);
            }
        }
