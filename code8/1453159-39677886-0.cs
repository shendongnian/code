        public static void Main(string[] args)
        {
            string xml = @"<Elements>
                        <Element>
                            <ElementID>A1</ElementID>
                            <ElementName>Element A</ElementName>
                            <ElementValues>
                                <ElementValue>
                                    <ValueText>A Value</ValueText>
                                    <ValueDescription>A Type Element</ValueDescription>
                                </ElementValue>
                            </ElementValues>
                        </Element>
                        <Element>
                            <ElementID>B1</ElementID>
                            <ElementName>Element B</ElementName>
                            <ElementValues>
                                <ElementValue>
                                    <ValueText>B Value</ValueText>
                                    <ValueDescription>B Type Element</ValueDescription>
                                </ElementValue>
                            </ElementValues>
                        </Element>
                        </Elements>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode root = doc.DocumentElement;
            /* Select all "<Element>" nodes which have an <ElementID> subnode where the text equals "B1". */
            var nodes = root.SelectNodes("//Element[ElementID/text() = \"B1\"]");
            
            foreach(XmlNode node in nodes){
                Console.WriteLine("Found matching Element: \n {0}", node.InnerXml);
            }
      }          
  
