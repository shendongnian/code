    SqlCommand Comm1 = new SqlCommand("Select Active from dbo.SQLInfrastructure WHERE [Instance] LIKE  '" + label1.Text + "%'", connn);
    connn.Open();
    SqlDataReader DR1 = Comm1.ExecuteReader();
    if (DR1 != null)    //or, while(DR1.Read())
    {
        this.activeCheckBox.Checked = false;
    }
    else
    {
        this.activeCheckBox.Checked = true;
    }
    connn.Close();
