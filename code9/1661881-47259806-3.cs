        public static String TransfromXMLWithXSLT1(String i_xmlData, String i_xsltCode)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            using (StringReader xsltStringReader = new StringReader(i_xsltCode)) {
                using (XmlReader xsltXmlReader = XmlReader.Create(xsltStringReader)) {
                    xslt.Load(xsltXmlReader);
                    using (StringReader tableStringReader = new StringReader(i_xmlData)) {
                        using (XmlReader tableXmlReader = XmlReader.Create(tableStringReader)) {
                            using (StringWriter stringWriter = new StringWriter()) {
                                xslt.Transform(tableXmlReader, new XsltArgumentList(), stringWriter);
                                return stringWriter.ToString();
                            }
                        }
                    }
                }
            }
        }
