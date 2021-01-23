    SqlCommand Comm1 = new SqlCommand("Select Active from dbo.SQLInfrastructure WHERE [Instance] LIKE  '" + label1.Text + "%'", connn);
    connn.Open();
    int value = Comm1.ExecuteReader();
    if (value ==1)
    {
        this.activeCheckBox.Checked = false;
    }
    else
    {
        this.activeCheckBox.Checked = true;
    }
    connn.Close();
