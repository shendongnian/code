    public static void AddNewAttribute(IEnumerable<XElement> elements)
    {
        foreach (XElement elm in elements)
        {
            elm.Add(new XAttribute("newAttr", 1));
            AddNewAttribute(elm.Elements());
        }
    }
