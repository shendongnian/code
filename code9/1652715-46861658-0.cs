    try
    {
        var xmlWriterSettings = new XmlWriterSettings() { Indent = true, NewLineOnAttributes = true };
        string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "config.xml");
        using (XmlWriter xmlWriter = XmlWriter.Create(path, xmlWriterSettings))
        {
            FHConfig obj = new FHConfig();
            XamlServices.Save(xmlWriter, obj);
        }
    }
    catch (Exception exep) { MessageBox.Show("Saving UI parameters: " + exep.Message); }
