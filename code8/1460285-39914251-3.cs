    var validNames = new List<string> {"oneofmyvalueIneed","anotherone","yetanother"}
    XDocument myDoc = XDocument.Parse(p);
    var result = from item in myDoc.Descendants("Item")
          where ((double)item.Element("orderedQuantity") > 0 &&                   
                item.Element("ResourceId").Name != "NULLOrderItem") && // See Charles's comment about this line
                validNames.Contains(iten.Element("Name").Value.ToLower())
          select item;
    foreach (var item in orderedRes)
    {
        FieldProperties elem = new FieldProperties();
        elem.Fieldname = xelem.Element("Name").Value;
        elem.Fieldvalue = xelem.Element("OrderedQuantity").Value;
        lElem.Add(elem);
    }
