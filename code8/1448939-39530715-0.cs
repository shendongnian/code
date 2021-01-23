    var dataListAddress = (from root in xmlDoc.Descendants("File")
                           from Data in root.Elements("Data")
                           where someCondition // first condition
                           select new
                           {
                               Name = Data.Element("name").Value,
                               ID = Data.Element("id").Value,
                               Address = Data.Element("address").Value 
                           }).ToList();
    var dataListHomeAddress = (from root in xmlDoc.Descendants("File")
                               from Data in root.Elements("Data")
                               where anotherCondition // second condition
                               select new
                               {
                                   Name = Data.Element("name").Value,
                                   ID = Data.Element("id").Value,
                                   HomeAddress = Data.Element("HomeAddress").Value 
                               }).ToList();
