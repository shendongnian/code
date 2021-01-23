     private void PopulateComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("myAtribute", typeof(string));
            
            XmlTextReader readXml = new XmlTextReader("comboXml.xml");
            try
            {
                while (readXml.Read()) 
                {
                    if (readXml.NodeType == XmlNodeType.Element)
                    {
                        switch (readXml.Name)
                        {
                            case "myAttribute":
                                DataRow dr = dt.NewRow();
                                dr["myAtribute"] = readXml.ReadString() ; 
                                dt.Rows.Add(dr);
                                break;
                        }
                    }
                }
                readXml.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Xml connection failed: " + ex.Message);
            }
            if (dt.Rows.Count > 0)
            {
                comboBox.DataSource = dt;    
            }
            else
            {
                MessageBox.Show("No source found!", "Warning");
            }
            
        }
