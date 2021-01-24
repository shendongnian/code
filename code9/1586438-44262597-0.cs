    foreach (var btn in Globals.LClickedButtons)
    {
        string xaml = System.Windows.Markup.XamlWriter.Save(btn);
        using (System.IO.StringReader stringReader = new System.IO.StringReader(xaml))
        {
            using (System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(stringReader))
            {
                Button newButton = (Button)System.Windows.Markup.XamlReader.Load(xmlReader);
                //...
            }
        }
    }
