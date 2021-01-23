    string testURL = "XML.xml";
    XDocument doc = XDocument.Load(testURL);
    string ns = doc.Root.GetDefaultNamespace().ToString();
    List<MonthlyInformation> result =
    doc.Descendants(XName.Get("MitarbeiterGroup", ns))
    .Select(x =>
    new MonthlyInformation
    {
        Name = (string)x.Attribute("Group9"),
        FinishedMonths = x.Descendants(XName.Get("Monat3", ns)).Select(s => new FinishedMonth
        {
            MonthName = (string)s.Attribute("Monat3"),
            Money = "money" //(string)s.Element("Cell").Attribute("Textbox142") 
        }).ToList(),
        ForecastMonths = x.Descendants(XName.Get("Monat9", ns)).Select(s => new ForecastMonth
        {
            MonthName = (string)s.Attribute("Monat9"),
            Money = "money" //(string)s.Element("Cell").Attribute("Textbox143")
        }).ToList()
    }).ToList();
