    void SaveData() {
            XDocument xmlDocument = new XDocument(new XElement("Grid"));
            foreach(DataGridViewRow row in dataGridView1.Rows)
            xmlDocument.Root.Add(
                new XElement("Grid",
                    new XAttribute("xxx1", row.Cells[0].Value.ToString()),
                    new XAttribute("xxx2", row.Cells[1].Value.ToString()),
                    new XAttribute("xxx3", row.Cells[2].Value.ToString()),
                    new XAttribute("xxx4", row.Cells[3].Value.ToString()),
                    new XAttribute("xxx5", row.Cells[4].Value.ToString()),
                    new XAttribute("xxx6", row.Cells[5].Value.ToString()),
                    new XAttribute("xxx7", row.Cells[6].Value.ToString())));
            xmlDocument.Save("@Path");
        }
        void LoadData() {
            try {
                XDocument xmlDocument = XDocument.Load("@Path");
                foreach(XElement el in xmlDocument.Root.Elements()) {
                    switch(el.Name.LocalName) {
                        case "Grid":
                            dataGridView1.Rows.Add(el.Attribute("xxx1").Value,el.Attribute("xxx2").Value,
                                el.Attribute("xxx3").Value,el.Attribute("xxx4").Value,el.Attribute("xxx5").Value,
                                el.Attribute("xxx6").Value,el.Attribute("xxx7").Value);
                            break;
                    }
                }
            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
