    private void btnReadXml_Click(object sender, EventArgs e)
            {
                var doc = XDocument.Load("C:\\dinamap.xml");
                var results = from result in doc.Descendants("Result")
                              select new
                              {
                                  Name = (string)result.Attribute("name"),
                                  Value = (string)result.Element("Value"),
                                  Units = (string)result.Element("Units").Attribute("name")
                              };
                foreach (var result in results)
                {
                    MessageBox.Show("{result.Name}: {result.Value} {result.Units}");
                }
             
            }
