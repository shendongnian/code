    public void fillCombo(ComboBox cb, string query, string displayMember, string valueMember) {
        cmd=new SqlCommand(query,c.con);
        SqlDataAdapter sda=new SqlDataAdapter(cmd);
        d.dt3.Clear();
        sda.Fill(d.dt3);
        cb.DataSource = d.dt3;
        cb.DisplayMember = displayMember;
        cb.ValueMember = valueMember;        
    }
    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int val;
        Int32.TryParse(comboBox2.SelectedValue.ToString(), out val);
        string q = "Select * From Tehsil where DistrictID =" + val;
        fillCombo(comboBox1, q, "Tehsil_name", "TehsilID");
    } 
