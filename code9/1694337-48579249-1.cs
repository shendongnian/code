    using System.Linq;
    using System.Xml.Linq;
    using static System.Console;
    string xml = @"<parent>
                        <control></control>
                        <option>
                          <data>
                          </data>
                        </option>
                        </parent>";
    
                // First let us parse the xml string using XElement
                var parsedXML = XElement.Parse(xml);
    
                // Now get the element from the <option>  tag.
                var firstElement = parsedXML.Element("option").Descendants().First();
                firstElement.Add(new XElement("TemplateID", "xxxx"));
                firstElement.Add(new XElement("CaptionOptions"));
    
                // You will use for loop here
                //{ 
                //firstElement.Element("CaptionOptions").Descendants().First().Add(new XElement("CaptionField"));
                firstElement.Element("CaptionOptions").Add(new XElement("CaptionField",
                                                               new XElement("Field", "xxxx"),
                                                               new XElement("Text", "hello")
                                                          ));
                
                //}
                WriteLine(parsedXML.ToString());
