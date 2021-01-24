                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(string));
                dt.Columns.Add("Max Temp", typeof(string));
                dt.Columns.Add("Min Temp", typeof(string));
                dt.Columns.Add("Text", typeof(string));
                dt.Columns.Add("Icon", typeof(string));
                
                string city = "London";
                string uri = string.Format("http://api.apixu.com/v1/forecast.xml?key=5742bec32f4141e08db171907171010&q={0}&days=7", city);
                
                XDocument doc = XDocument.Load(uri);
                foreach (var npc in doc.Descendants("forecastday"))
                {
                    dt.Rows.Add(new object[] {
                        (string)npc.Descendants("date").FirstOrDefault(),
                        (string)npc.Descendants("maxtemp_c").FirstOrDefault(),
                        (string)npc.Descendants("mintemp_c").FirstOrDefault(),
                        (string)npc.Descendants("text").FirstOrDefault(),
                        (string)npc.Descendants("http" + "icon").FirstOrDefault()
                    });
                }
                datagridview1.DataSource = dt;
