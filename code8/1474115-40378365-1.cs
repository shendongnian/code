        protected void RadComboBox1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.Text=="NADA")
        { Label1.Visible = true; Label2.Visible = true; }
        else if (e.Text == "grvUser")            
        {Label1.Visible=true; Label2.Visible=false;}
        else if (e.Text == "grvRole")
        { Label1.Visible = false; Label2.Visible = true; }
    }
