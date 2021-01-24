            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            MemoryStream ms = new MemoryStream();
            SqlCommand cmd = null;
            using (XmlWriter writer = XmlWriter.Create(ms, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        writer.WriteStartElement("AuditHistory");
                        writer.WriteStartElement("rowid");
                        writer.WriteString(Convert.ToString(sdr["rowid"]));
                        writer.WriteEndElement(); //end rowid
                        writer.WriteStartElement("rowname");
                        writer.WriteString(Convert.ToString(sdr["rowname"]));
                        writer.WriteEndElement();//end rowname
                        writer.WriteStartElement("rcount");
                        writer.WriteString(Convert.ToString(sdr["rcount"]));
                        writer.WriteEndElement();//end rcount
                        writer.WriteEndElement();//end AuditHistory
                    }
                }
                writer.WriteEndElement();// end root
                writer.WriteEndDocument();
                writer.Flush();
            }
