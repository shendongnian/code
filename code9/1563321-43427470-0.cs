    var data = XDocument.Load("data.xml")
                        .Descendants("Bike")
                        .FirstOrDefault(item => item.Attribute("Id").Value == "1");
    if(data != null)
    {
        Bike bike = new Bike(data.Attribute("Id").Value,
                             data.Element("Small_Picture").Value,
                             data.Element("Model").Value,
                             data.Element("Price").Value);
    }
