	private void CreateBox(Dictionary<dynamic, List<dynamic>> dictionary)
	{
		int y = 0;
		int z = 0;
		CheckBox box;
		for (int x = 1; x < dictionary.Count(); x++)
		{
			List<dynamic> folder = dictionary[x];
			box = new CheckBox();
			box.CheckedChanged += box_CheckedChanged; // here
			box.Text = folder[0];
			box.AutoSize = true;
			box.Checked = folder[1];
			this.Controls.Add(box);
		}
	}
	
	private void box_CheckChanged(object sender, EventArgs e)
	{
		// some code here.
	}
