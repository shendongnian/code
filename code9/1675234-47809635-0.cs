    using (MySqlConnection con = new MySqlConnection("Server=166.62.27.186;Database=xxxx;Uid=xxxx;Pwd=xxxx;"))
    {
        con.Open();
        using (MySqlCommand cmd = new MySqlCommand("select * from appoint order by times asc", con))
        {
            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem Item = new ListViewItem(dr["Customer"].ToString());
                Item.SubItems.Add(dr["Kind"].ToString());
                Item.SubItems.Add(dr["connum"].ToString() + "/" + dr["telnum"].ToString());
                Item.SubItems.Add(dr["times"].ToString());
                Item.SubItems.Add(dr["address"].ToString());
                Item.SubItems.Add(dr["type"].ToString());
                Item.SubItems.Add(dr["notes"].ToString());
                listView10.Items.Add(Item);
            }
        }
        con.Close();
    }
