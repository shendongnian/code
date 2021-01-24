    public void Save(ContactDB db)
    {
        FileStream wfs = new FileStream(fileAddress, FileMode.Create, FileAccess.Write);
        XmlSerializer serialobj = new XmlSerializer(typeof(ContactDB));
        serialobj.Serialize(wfs, db);
        wfs.Close();
    }
