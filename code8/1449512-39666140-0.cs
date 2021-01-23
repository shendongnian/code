     // XML Deserialization helper.
    class XmlSerializationHelper
    {
        // Transform the input xml to the desired format needed for de-serialization.
        private static string TransformXml(string xmlString)
        {
            // XSL transformation script.
            string xsl = @"<xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" version=""1.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                          <xsl:template match=""MyFruit"">
                              <xsl:element name=""{local-name()}"">
                                <Fruits>
                                  <xsl:for-each select=""Fruit"">
                                      <xsl:element name=""Fruit"">
                                         <xsl:attribute name=""xsi:type""><xsl:value-of select=""Name""/></xsl:attribute>
                                         <xsl:copy-of select=""./node()""/>
                                      </xsl:element>
                                   </xsl:for-each>
                                </Fruits>
                               </xsl:element>
                            </xsl:template>
                        </xsl:stylesheet>";
            // Load input xml as XmlDocument
            XmlDocument sourceXml = new XmlDocument();
            sourceXml.LoadXml(xmlString);
            // Create XSL transformation.
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(new XmlTextReader(new StringReader(xsl)));
            // Apply transformation to input xml and write result out to target xml doc.
            XmlDocument targetXml = new XmlDocument(sourceXml.CreateNavigator().NameTable);
            using (XmlWriter writer = targetXml.CreateNavigator().AppendChild())
            {
                transform.Transform(sourceXml, writer);
            }
            // Return transformed xml string.
            return targetXml.InnerXml;
        }
        public static T DeSerialize<T>(string inputXml)
        {
            T instance = default(T);
            if (string.IsNullOrEmpty(inputXml))
                return instance;
            try
            {
                string xml = TransformXml(inputXml);  // Transform the input xml to the desired xml format needed to de-serialize objects.
                string attributeXml = string.Empty;
                using (StringReader reader = new StringReader(xml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (XmlReader xmlReader = new XmlTextReader(reader))
                    {
                        instance = (T)serializer.Deserialize(xmlReader);
                        xmlReader.Close();
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return instance;
        }
    }
