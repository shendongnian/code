    var emails = xmlContent.Root.Elements("Resources").Elements("item").Elements("emails");
            foreach (XElement elem in emails)
            {
                Console.Write(elem.Value);
            }
