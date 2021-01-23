	List<List<Control>> contrlList = new List<List<Control>>();
	for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
	{
		DateTimePicker newDTP = new DateTimePicker();
		ComboBox newCB = new ComboBox();
		newCB.SelectedIndexChanged += comboBox_SelectedIndexChanged;
		Label newL = new Label();
		List<Control> rowControls = new List<Control>()
			{
				newDTP,
				newCB,
				newL
			};
		for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
		{
			tableLayoutPanel1.Controls.Add(rowControls[col], col, row);
			contrlList.Add(rowControls);
		}
	}
