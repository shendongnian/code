        public static string ConvertCSVToXML(string filePath, char seperator)
        {
            var lines = File.ReadAllLines(filePath);
            var headers = lines[0].Split(seperator);
            XElement xml = new XElement("RootElement",
                                lines.Select(line => new XElement("Item",
                                    line.Split(seperator).Select((column, index) => 
                                       new XElement(headers[index], column))
                                ))
                            );
            return xml.ToString();
        }
