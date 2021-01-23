    SqlCommand Comm1 = new SqlCommand("Select Active from dbo.SQLInfrastructure WHERE [Instance] LIKE  '" + label1.Text + "%'", connn);
    connn.Open();
    SqlDataReader DR1 = Comm1.ExecuteReader();
    this.activeCheckBox.Checked = DR1.Read() && DR.GetBoolean(0);
    connn.Close();
