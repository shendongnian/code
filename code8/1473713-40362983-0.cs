            var result = doc.Root.Elements().Where(x => x.Name == "Observation").ToList();
            doc.Root.Elements().Where(x => x.Name == "Observation").Remove();
            List<XDocument> docList = new List<XDocument>();
            foreach(var el in result)
            {
                XDocument d = new XDocument(doc);
                d.Root.Add(el);
                docList.Add(d);
            }
