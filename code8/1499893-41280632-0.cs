    private static IEnumerable<XElement> StreamElements(string fileName, string elementName)
        {
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                while (reader.Name == elementName || reader.ReadToFollowing(elementName))
                {
                    yield return (XElement)XNode.ReadFrom(reader);
                }
                reader.Close();
            }
        }
