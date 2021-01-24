    private void populate()
        {
        listView1.Items.Clear();
        SqlCommand cm;
        if(textBox1.Text == "")
           cm = new SqlCommand("SELECT * FROM dbName", con);
        else
            cm = new SqlCommand("SELECT * FROM dbName WHERE Nome='" + txtBoxName.Text + "'", con);
        try
        {
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem it = new 
                ListViewItem(dr["fillingcode"].ToString());
                it.SubItems.Add(dr["ID"].ToString());
                it.SubItems.Add(dr["Nome"].ToString());
                it.SubItems.Add(dr["Convenio"].ToString());
                it.SubItems.Add(dr["Contato"].ToString());
                listView1.Items.Add(it);
            }
            dr.Close();
            dr.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
