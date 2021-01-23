            string pathToXmlFile = "";
            XDocument document = XDocument.Load(pathToXmlFile);
            var coordinates = document.Descendants("coordinates");
            string pathToTextFile = "";
            StreamWriter streamWriter = new StreamWriter(pathToTextFile);
            foreach (XElement coordinate in coordinates)
            {
                streamWriter.WriteLine(coordinate.Value);
                Console.WriteLine(coordinate.Value);
            }
            
            streamWriter.Close();
