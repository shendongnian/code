    protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    	{
    		List<string> strCheckList = new List<string>();
    		if (CheckBox1.Checked) {
    			strCheckList.Add(CheckBox1.Text);
    		}
    		if (CheckBox2.Checked)
    		{
    			strCheckList.Add(CheckBox2.Text);
    		}
    		if (CheckBox3.Checked)
    		{
    			strCheckList.Add(CheckBox3.Text);
    		}
    		Label1.Text = string.Join(",", strCheckList);
    	}
