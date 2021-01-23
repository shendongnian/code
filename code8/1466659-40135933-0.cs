     XElement xelement = XElement.Parse(xmlstr);
     //var controls = xelement.Descendants("ControlsLayout");
     var controls = xelement.Descendants("Object");
     foreach (var control in controls)
     {
        var xElement = control.Elements("Property");
        foreach (var element in xElement)
        {
            if (element != null)
            {
                var xAttribute = element.Attribute("name");
                if (xAttribute != null && xAttribute.Value == "ControlLabel")
                { Console.WriteLine(element.Value); }
                if (xAttribute != null && xAttribute.Value == "Name")
                { Console.WriteLine(element.Value); }
            }
        }
                    
     }
