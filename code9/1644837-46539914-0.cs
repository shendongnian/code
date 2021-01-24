    public static InformationNode fromXML(String xml)
    {
        xml = xml.Replace("< ", "<").Replace("</ ", "</"); //Bugfix for some API's.
        var xdoc = XDocument.Parse(xml);
        var details = xdoc.Root.Elements();
        var key = "->";
    
        var node = new InformationNode(key, "", InformationType.Object);
        
        if(details != null && details.Any())
        {
            foreach (var detail in details)
            {
                //If XML is object, recurse:
                node.addChild(fromXML(detail.Value.Trim()));                
            }
        }
        else
        {
            var rootValue = xdoc.Root.Value().Trim();
            
            //If XML is Leaf.
            if (int.TryParse(rootValue, out var n))
            {
                node = InformationNode(key, rootValue, InformationType.Int);
            }
            else
            {
                node = InformationNode(key, rootValue, InformationType.String);
            }
        }
        
        return node;
    }
