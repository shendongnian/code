    public void Save(List<Contact> lstContact)
    {
        FileStream wfs = new FileStream(fileAddress, FileMode.Create, FileAccess.Write);
        XmlSerializer serialobj = new XmlSerializer(typeof(List<Contact>));
        serialobj.Serialize(wfs, lstContact);
        wfs.Close();
    }
