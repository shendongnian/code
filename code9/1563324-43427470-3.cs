    Bike x = (from bike in XDocument.Load("data").Descendants("Bike")
              select new Bike(bike.Attribute("Id").Value, 
                              bike.Element("Small_Picture").Value, 
                              bike.Element("Model").Value, 
                              bike.Element("Price").Value))
             .FirstOrDefault(item => item.Id == 1);    
