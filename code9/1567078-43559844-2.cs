        // Load Document
        XDocument _doc = XDocument.Load("C:\\t\\My File2.txt");
        // Get all Entity elements and put them into a list.
        List<XElement> employees = _doc.XPathSelectElements("ROOT/Entity").ToList();
        // Next you can loop thrue the list to check the Entitys elements
        foreach (var employee in employees)
        {
            string armor = employee.Element("Armor").Value;
            string rarity = employee.Element("Rarity").Value;
            string stat = employee.Element("Stats").Element("Stat").Value;
            string slot = employee.Element("Slots").Element("Slot").Value;
        }
        // To get one element specific by attribute use this (I check on attribute ID):
          XElement emp = _doc.XPathSelectElements("ROOT/Entity").FirstOrDefault(c => c.Attribute("ID").Value == "0");
