    void CheckList_Bikes()
    {
        if(client.SelectedIndex != -1)
        {
            int idcl = Convert.ToInt32(client.SelectedValue.ToString());
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@idclient", idcl);
            adaptb.Fill(biciT);
            bikes.Items.Clear();
            bikes.DataSource = biciT;
            bikes.ValueMember = "ID";
            bikes.DisplayMember = "name";
        }
    
    }
