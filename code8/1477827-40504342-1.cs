            var xmlSerializer = new XmlSerializer(typeof(Items), new XmlRootAttribute("items"));
            using (TextReader textReader = new StringReader(xmlString))
            {
                var items = (Items)xmlSerializer.Deserialize(textReader);
                var itemCount = items.Item.Length;
            }
