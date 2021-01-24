    void CheckList_Bikes()
    {
        int idcl = 0;
        if(Int.TryParse(client.SelectedValue.ToString(), out idcl)
        {
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@idclient", idcl);
            adaptb.Fill(biciT);
            bikes.Items.Clear();
            bikes.DataSource = biciT;
            bikes.ValueMember = "ID";
            bikes.DisplayMember = "name";
        }
    
    }
