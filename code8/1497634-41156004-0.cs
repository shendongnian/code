	List<List<Control>> contrlList = new List<List<Control>>();
	for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
	{
		List<Control> rowControls = new List<Control>()
			{
				new DateTimePicker(),
				new TextBox(),
				new Label()
			};
		for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
		{
			tableLayoutPanel1.Controls.Add(rowControls[col], col, row);
			contrlList.Add(rowControls);
		}
	}
