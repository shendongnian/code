        private void btn_Save_Click(object sender, EventArgs e)
        {
            string num = txtnum.Text;
            string id = txtid.Text;
            string age = txtage.Text;
            string date = txtdate.Text;
            XmlTextWriter writer = new XmlTextWriter(@"C:\Users\Public\Desktop\Details.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("MDS");
            create_node(num, id, age,date, writer);           
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("XML File created ! ");
        }
