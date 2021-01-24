    public ObservableCollection<Communication> GetCommunications()
    {
        ObservableCollection<Communication> communications = new ObservableCollection<Communication>();
        XDocument doc = XDocument.Load("Communications.xml");
        foreach (XElement communicationRow in doc.Root.Elements("Communications"))
        {
            var c = new Communication((ushort)Convert.ToInt16(communicationRow.Element("ModelNumber").Value), communicationRow.Element("ParamName").Value,
                    communicationRow.Element("DefaultValue").Value, communicationRow.Element("DefaultValue").Value, communicationRow.Element("MaxValue").Value,
                    communicationRow.Element("MinValue").Value);
            foreach (XElement paramValue in communicationRow.Element("ParamValues").Elements())
            {
                c.ParamValues.Add(paramValue.Value);
            }
            communications.Add(c);
        }
        return communications;
    }
