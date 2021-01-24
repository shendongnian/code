    public Form2(BindingSource dataSource)
    {
    
    SQLiteDataAdapter DEPDataAdapter = new SQLiteDataAdapter("select * from DEPARTMENT", dbc);
    DataSet DEPdata = new DataSet();
    DEPDataAdapter.Fill(DEPdata, "DEPARTMENT");
    
    TextBoxEmpID.DataBindings.Add("Text", dataSource, "ID".ToString(), true);
    TextBoxfName.DataBindings.Add("Text", dataSource, "FNAME", true);
    TextBoxlName.DataBindings.Add("Text", dataSource, "LNAME", true);
    TextBoxDEP.DataBindings.Add("Text", dataSource, "DEPNO".ToString(), true);
    TextBoxComment.DataBindings.Add("Text", dataSource, "Comment", true);
    
    ComboBoxDEP.DataSource = DEPdata.Tables["DEPARTMENT"];
    ComboBoxDEP.DisplayMember = "DEPNAME";
    ComboBoxDEP.ValueMember = "DEPNO";
    
    ComboBoxDEP.SelectedValue = ((DataRowView)this.datasource.Current).Row["DEPNO"];
    }
    
    private void ComboBoxDEP_SelectionChangeCommitted(object sender, EventArgs e)
    {
    	TextBoxDEP.Text = ComboBoxDEP.SelectedValue.ToString();
    }
