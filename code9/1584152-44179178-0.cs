    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace CangeOneXmlToAnotherXmlConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sourceXml = @"<Dress>
                                    <ID>001</ID>
                                    <shirts>
                                        <product>
                                            <ID>345</ID>
                                            <Name>tee</Name>
                                            <Serial>5678</Serial>
                                        </product>
                                        <product>
                                            <ID>456</ID>
                                            <Name>crew</Name>
                                            <Serial>4566</Serial>
                                        </product>       
                                    </shirts>
                                    <pants>
                                        <product>
                                            <ID>123</ID>
                                            <Name>jeans</Name>
                                            <Serial>1234</Serial>
                                            <Color>blue</Color>
                                        </product>
                                        <product>
                                            <ID>137</ID>
                                            <Name>skirt</Name>
                                            <Serial>3455</Serial>
                                            <Color>black</Color>
                                        </product>
                                    </pants>
                                </Dress>";
                var xmlDoc = XDocument.Parse(sourceXml);
                //Remove the ID element
                var firstChildNodeVal = ((XElement)((XContainer)xmlDoc.FirstNode).FirstNode).Value;
                xmlDoc.Descendants("ID").Remove();
                //Add an attribute(ID) with value to the root element
                xmlDoc.Root.SetAttributeValue("ID", firstChildNodeVal);
                //Define the new elements to be available inside the root element
                var elemetsToBeFormatted = new string[] { "shirts", "pants" };
                //Loop it and add the elements inside root element
                foreach (var item in elemetsToBeFormatted)
                {
                    var aitem = xmlDoc.Root.Elements(item).Elements("product").ToList();
                    aitem.ForEach(p => p.Elements().ToList().ForEach(e => { p.SetAttributeValue(e.Name, e.Value); e.Remove(); }));
                }
                var expectedXml = xmlDoc.ToString();
                Console.WriteLine(expectedXml);
                Console.Read();
            }
        }
    }
