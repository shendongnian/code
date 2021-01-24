    tableLayoutPanel1.Update(); //not sure if necessary yet
	if (!tableLayoutPanel1.VerticalScroll.Visible) {
		tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
		tableLayoutPanel1.Controls.Add(new Control(), 0, inp.Count);
		tableLayoutPanel1.Controls.Add(new Control(), 1, inp.Count);
		tableLayoutPanel1.Controls.Add(new Control(), 2, inp.Count);
	} else if (tableLayoutPanel1.HorizontalScroll.Visible) {
		if (tableLayoutPanel1.RowStyles.Count != inp.Count) {
			tableLayoutPanel1.GetControlFromPosition(0, inp.Count).Dispose();
			tableLayoutPanel1.GetControlFromPosition(1, inp.Count).Dispose();
			tableLayoutPanel1.GetControlFromPosition(2, inp.Count).Dispose();
			tableLayoutPanel1.RowStyles.RemoveAt(inp.Count);
		} else {
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0));
			tableLayoutPanel1.Controls.Add(new Control(), 0, inp.Count);
			tableLayoutPanel1.Controls.Add(new Control(), 1, inp.Count);
			tableLayoutPanel1.Controls.Add(new Control(), 2, inp.Count);
			tableLayoutPanel1.GetControlFromPosition(0, inp.Count).Dispose();
			tableLayoutPanel1.GetControlFromPosition(1, inp.Count).Dispose();
			tableLayoutPanel1.GetControlFromPosition(2, inp.Count).Dispose();
			tableLayoutPanel1.RowStyles.RemoveAt(inp.Count);
		}
	}
