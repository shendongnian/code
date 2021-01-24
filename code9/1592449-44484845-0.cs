	private List<List<CheckBox>> CheckBoxes = new List<List<CheckBox>>();
	private void button1_Click(object sender, EventArgs e)
	{
		int numberOfRows = 5;
		int numberOfColumns = 10;
		CheckBoxes.Clear();
		for (int y = 0; y < numberOfRows; y++)
		{
			List<CheckBox> row = new List<CheckBox>();
			CheckBoxes.Add(row);
			for (int x = 0; x < numberOfColumns; x++)
			{
				var checkbox = new CheckBox();
				checkbox.Text = "";
				checkbox.AutoSize = true;
				checkbox.Location = new Point(20 * x, 20 * y);
				row.Add(checkbox);
				this.Controls.Add(checkbox);
			}
		}
	}
