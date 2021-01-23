    public void fillCombo(ComboBox cb, string query, string displayMember, string valueMember, int districtID) {
        cmd=new SqlCommand(query,c.con);
        SqlDataAdapter sda=new SqlDataAdapter(cmd);
        sda.Fill(d.dt3);
        var comboView = d.dt3; //Assuming d.dt3 is a DataTable, if it is dataset you will need d.dt3.Tables["table_name"] or [index]
        comboView.DefaultView.RowFilter = string.Format("{0}={1}", "DistrictID", districtID); //This should filter the view being bound to CB.
        cb.DataSource = comboView;
        cb.DisplayMember = displayMember;
        cb.ValueMember = valueMember;        
        cb.DataBind(); //Explicit Call to Databind
    }
    // you will be calling it as below
    fillCombo(comboBox1, q, "Tehsil_name", "TehsilID", val); //val is district ID as assigned in your comboBox2_SelectedIndexChanged event handler.
