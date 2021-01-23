    public void SauvegarderList(string xmlFilePath)
    {
        XmlSerializer xmlSer = new XmlSerializer(typeof(ListDevis));
        using (StreamWriter streamW = new StreamWriter(xmlFilePath))
        {
            xmlSer.Serialize(streamW, List);
        }
    }
