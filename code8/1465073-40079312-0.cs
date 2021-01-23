     //recreates file if there is already one.
        XmlTextWriter xmlFile = new XmlTextWriter("comboXml.xml", System.Text.UTF8Encoding.UTF8);
        
        
        //intened formatting
        xmlFile.Formatting = Formatting.Indented;
         private void Add_Click(object sender, RoutedEventArgs e)
                {
                  comboBox.Items.Add(textbox.Text);
                try
                 {
                  xmlFile.WriteStartDocument(); 
                  xmlFile.WriteStartElement("myData");
                  xmlFile.WriteElementString("myAttribute", textbox.Text);
            
             
                  xmlFile.WriteEndElement();
                  xmlFile.Close();
         
                 }
                 catch (Exception ex)
                  {
                     MessageBox.Show("Xml Writing Failed:" + ex.Message); 
                  }
        
                    
                    MyPopup.IsOpen = false;
        }
