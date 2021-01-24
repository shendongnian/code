    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        const string filename = "test.xml";
        XmlTextWriter xWriter = new XmlTextWriter(filename, Encoding.UTF8);
        xWriter.Formatting = System.Xml.Formatting.Indented;
        xWriter.WriteStartElement("root");
        testViewClassDataContext dc = new testViewClassDataContext();
        List<test_view> tvq = (from tt in dc.test_views
                               select tt).ToList();
        var propertiesTestView = typeof(test_view).GetProperties();
        var testViewValues = new List<string>();
        loopPropXML(tvq, propertiesTestView, testViewValues, xWriter);
        xWriter.WriteEndElement();
        xWriter.Close();
        string unencrypted = File.ReadAllText(filename);
        DESEncrypt testEncrypt = new DESEncrypt();
        string pass = "qwertyuiop";
        string encText = testEncrypt.EncryptString(unencrypted, pass);
        File.WriteAllText(filename, encText);
    }
