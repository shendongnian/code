     private void stationCBO_SelectedIndexChanged(object sender, EventArgs e)
     {
         codeCBO.Items.Clear();
         LoadXML(stationCBO.Text);
     }
    private void LoadXML(string station)
        {
            XmlReader reader = XmlReader.Create("Failure_Modes.xml");
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == station))
                {
                    if (reader.HasAttributes)
                    {
                        string text = reader.GetAttribute("code") + "-" + reader.GetAttribute("description");
                        codeCBO.Items.Add(text);
                    }
                }
            }
        }
