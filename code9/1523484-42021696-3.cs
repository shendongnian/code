    protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    	{
    	     List<CheckBox> foodCheckBoxList = new List<CheckBox>();
		     foodCheckBoxList.Add(CheckBox1);
		     foodCheckBoxList.Add(CheckBox2);
		     foodCheckBoxList.Add(CheckBox3);
		     foodCheckBoxList.Where(x => x.Checked).Select(x=>x.Text);
		     Label1.Text = string.Join(",", foodCheckBoxList.Where(x => x.Checked).Select(x => x.Text));
    	}
