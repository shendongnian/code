    public void BindTreatmentComboBox(CheckComboBox comboBoxName)
    {
    	...
    	try
    	{
    		conn.Open();
    		CmdString = "SELECT Id, ChargeName FROM Charges";
    		SqlDataAdapter da = new SqlDataAdapter(CmdString, conn);
    		DataSet ds = new DataSet();
    		da.Fill(ds, "Charges");
            var data = ds.Tables["Charges"].DefaultView;
    		comboBoxName.DisplayMemberPath = "ChargeName"
    		comboBoxName.ValueMemberPath = "Id"
    		comboBoxName.ItemsSource = data;    
    	}
    	...
    }
