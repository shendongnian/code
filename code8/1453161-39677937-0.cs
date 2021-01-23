    var doc = XDocument.Parse(xml);
    
    // retrieve the parent node of A1
    XElement a1 = doc.Root.Elements("Element")
                          .First(x => x.Element("ElementID").Value == "A1");
    
    // a1 now has an XML structure of:
    // <Element>
    //   <ElementID>A1</ElementID>
    //   <ElementName>Element A</ElementName>
    //   <ElementValues>
    //     <ElementValue>
    //       <ValueText>A Value</ValueText>
    //       <ValueDescription>A Type Element</ValueDescription>
    //     </ElementValue>
    //   </ElementValues>
    // </Element>
     
    // get the value of ValueText w/ a verbose path:
    string verbosePath = a1.Element("ElementValues")
                           .Element("ElementValue")
                           .Element("ValueText").Value;
    // alternatively, short-circuit the path:
    string shortPath = a1.Descendants("ValueText").First().Value;
