    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.XPath;
    using System.IO;
    namespace ConsoleApplication16
    {
        class Program
        {
            const string SCHEMA_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                //textBox1 Contains the xml text
                string xml = "<urn:PersonalDetails xmlns:urn=\"http://tempuri.org/XMLSchema.xsd\">" +
                         "<urn:yearJoined></urn:yearJoined>" +
                         "<urn:yearReleased>2017</urn:yearReleased>" +
                     "</urn:PersonalDetails>";
                      
                StringReader reader = new StringReader(xml);
                XmlTextReader xmlReader = new XmlTextReader(SCHEMA_FILENAME);
                Exception xsdException = new Exception();
                try
                {
                    bool isValid = IsXmlValidForSchema(reader, xmlReader, ref xsdException);
                    if (isValid)
                    {
                        Console.WriteLine("Success");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            public static void ValidateXml(
        StringReader srXML,
        XmlTextReader xtrSchema)
            {
                XmlSchemaSet xssValidate = null;
                try
                {
                    xssValidate = new XmlSchemaSet();
                    xssValidate.Add(null, xtrSchema);
                    xssValidate.Compile();
                    XPathDocument xpdValidate = new XPathDocument(srXML);
                    XPathNavigator editor = xpdValidate.CreateNavigator();
                    if (!editor.CheckValidity(xssValidate, ValidateEventHandler))
                    {
                        throw new System.Xml.Schema.XmlSchemaValidationException();
                    }
                }
                finally
                {
                    if (xssValidate != null) xssValidate = null;
                }
            }
            public static bool IsXmlValidForSchema(
                StringReader xmlReader,
                XmlTextReader schemaReader, ref Exception xsdException)
            {
                bool result = true;
                try
                {
                    ValidateXml(xmlReader, schemaReader);
                }
                catch (XmlSchemaValidationException ex)
                {
                    xsdException = ex;
                    result = false;
                }
                return result;
            }
            private static void ValidateEventHandler(object sender, ValidationEventArgs e)
            {
                if (e.Severity == XmlSeverityType.Error || e.Severity == XmlSeverityType.Warning)
                {
                    XmlSchemaException schemaException = new XmlSchemaException(e.Message, e.Exception);
                    throw schemaException;
                }
            }
        }
     
    }
