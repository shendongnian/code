       doc.Load("data.xml");
        foreach (XmlNode node in doc.SelectNodes("//RegisterInfo"))
        {
            //default xpath will be /RegisterInfo/Data1 and will not find the (Data Element) in (RegisterInfo)
            String Username = node.SelectSingleNode("Data1").Value; // so this will be null
            String Password = node.SelectSingleNode("Data3").Value; // so this will be null
            // can't compare null, so null error will be thrown.
            if (Username == nameTextBox.Text && Password == passwordTextBox.Text)
            {
            }
        }
      
