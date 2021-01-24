    private void Form1_Load(object sender, EventArgs e){
        //ListViewItem lis = new ListViewItem();
        using (XmlReader reader = XmlReader.Create("chatroomdoc.xml"))
        {
            int i =0;
            while (reader.Read())
            {
                    ListViewItem lis = new ListViewItem();
                    switch (reader.Name.ToString())
                    {
                        case "Nickname":
                            lis.Text=reader.ReadElementContentAsString();
                        break;
                        case "Message":
                            lis.SubItems.Add(reader.ReadElementContentAsString());
                        break;
                    }
                    lvmess.Items.Add(lis);
                //i++;
            }
           // lvmess.Items.Add(lis);
        }
    }
