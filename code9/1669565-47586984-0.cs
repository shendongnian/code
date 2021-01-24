    using(SqlCommand cmd = new SqlCommand())
    {
        cn.Open();
        cmd.CommandText = "select BookID, Author, Title, YEAR([Year]), Category, Availability from Bibliography where Author LIKE  @searchString";
        cmd.Parameters.AddWithValue("@searchString", "%" + searchString.Text + "%"); 
        cmd.Connection = cn;
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
             ListViewItem lv = new ListViewItem(dr[0].ToString());
             lv.SubItems.Add(dr[1].ToString());
             lv.SubItems.Add(dr[2].ToString());
             lv.SubItems.Add(dr[3].ToString());
             lv.SubItems.Add(dr[4].ToString());
             lv.SubItems.Add(dr[5].ToString());
             listViewLLReader.Items.Add(lv);
         }
         cn.Close();
    }
