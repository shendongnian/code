                    DataTable dt = new DataTable();
                dt.Columns.Add("Data");
                foreach (XmlNode xns in doc.DocumentElement)
                {
                    if (xns.Name == "Settembre") ///IMPLEMENTARE SELEZIONE AUTOMATICA DEL MESE IMPORTANTE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
                        foreach (XmlNode xn in xns)
                        {
                            string tagName = xn.Name;
                            var a = dt.Rows.Add(tagName);
                         //   int index_of_a = dt.Rows.IndexOf(a);
                        }
                }
                dt.Columns.Add("Mattina Turno 1");
                dt.Columns.Add("Mattina Turno 2");
                dt.Columns.Add("Pomeriggio");
                expo_days.DataSource = dt;
                expo_days.DataBind();
                foreach (XmlNode xns in doc.DocumentElement)
                {
                    if (xns.Name == "Settembre") ///IMPLEMENTARE SELEZIONE AUTOMATICA DEL MESE IMPORTANTE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
                        foreach (XmlNode xn in xns)
                        {
                            string tagName = xn.Name;
                            var a = dt.Rows.Add(tagName);
                            //   int index_of_a = dt.Rows.IndexOf(a);
                            DataRow[] rows = dt.Select("Data = '"+tagName+"'");
                            foreach (XmlNode xna in xn)
                            { //sistemare le celle in base alla colonna della gridview
                                if(xna.Name == "Mattina_Turno_1") //here i specify in wich column is the "Mattina_Turno_1" and fill in that cell, and so on
                                expo_days.Rows[dt.Rows.IndexOf(rows[0])].Cells[3].Text = xna.InnerText;
                                if (xna.Name == "Mattina_Turno_2")
                                    expo_days.Rows[dt.Rows.IndexOf(rows[0])].Cells[4].Text = xna.InnerText;
                                if (xna.Name == "Pomeriggio")
                                    expo_days.Rows[dt.Rows.IndexOf(rows[0])].Cells[5].Text = xna.InnerText;
                            }
                        }
                }
