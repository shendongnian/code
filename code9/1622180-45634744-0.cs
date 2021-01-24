        public static string ConvertCSVToXML(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var headers = lines[0].Split(',');
            XElement xml = new XElement("RootElement",
                                lines.Select(line => new XElement("Item",
                                    line.Split(',').Select((column, index) => 
                                       new XElement(headers[index], column))
                                ))
                            );
            return xml.ToString();
        }
