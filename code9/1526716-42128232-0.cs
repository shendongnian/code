    sensorpanel.Name = "panel" + j.ToString();
    this.Controls.Add(sensorpanel);
    
    :
    :
    cb.Text = "Occupancy";
    cb.Tag = "panel Index = " + j.ToString();
    cb.Name = "panel" + j.ToString() + "_" + "cb_" + cb.Text;
    sensorpanel.Controls.Add(cb);
    
    
    void cb_CheckedChanged(object sender, EventArgs e)
    {
    	CheckBox checkbox = (CheckBox)sender;
    	string mssg;
    	mssg = "Name = " + checkbox.Name;
    	mssg = "tag = " + checkbox.Tag;
    	mssg = "Parent text = " + checkbox.Parent.Text;
    	mssg = "Parent name = " + checkbox.Parent.Name;
    	MessageBox.Show(mssg);
    }
