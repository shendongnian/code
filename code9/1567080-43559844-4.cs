        // Load Document
        XDocument _doc = XDocument.Load("C:\\t\\My File2.txt");
        // Get all Entity elements and put them into a list.
        List<XElement> employees = _doc.XPathSelectElements("ROOT/Entity").ToList();
        // Next you can loop thru the list to check the Entity's elements
        foreach (var employee in employees)
        {
            // to get the armor element: 
            string armor = employee.Element("Armor").Value;
            // to get the rarity element:
            string rarity = employee.Element("Rarity").Value;
            // to get the Stat element:
            string stat = employee.Element("Stats").Element("Stat").Value;
            // to get the Slot element:
            string slot = employee.Element("Slots").Element("Slot").Value;
        }
        // To get one element specific by attribute use this (I check on attribute ID):
          XElement emp = _doc.XPathSelectElements("ROOT/Entity").FirstOrDefault(c => c.Attribute("ID").Value == "0");
        // Next you can extract information from this element just like in the foreach loop.
