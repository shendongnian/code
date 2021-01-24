    CheckBox[] chk = new CheckBox[dt.Columns.Count];
    for (int i = 0; i <= dt.Columns.Count - 1; i ++)
	{
		chk[i] = new CheckBox();
		chk[i].Name = dt.Columns[i].ColumnName;
		chk[i].Text = dt.Columns[i].ColumnName;
		chk[i].AutoCheck = true;
		chk[i].Bounds = new Rectangle(10, 20 + padding + dynamicHeight, 40, 22);
		panelCol.Controls.Add(chk[i]);
		dynamicHeight += 20;
		panelCol.Size = new Size(120, dynamicHeight);
		panelCol.Controls.Add(chk[i]);
		chk[i].Location = new Point(0, dynamicHeight);
		chk[i].Size = new Size(120, 21);
		panelCol.BackColor = Color.White;
		panelCol.AutoScroll = true;
		//panelCol.AutoScrollMinSize = new Size (0, 1200);
		chk[i].CheckedChanged += (s, ev) =>
		{
			decimal num;
			if (chk[i].Checked == true && chk[i].Name.Contains(dt.Columns[0].ColumnName))
			{
			//MessageBox.Show("HELLOW WORLD " + 0);
			  for (int i = 0; i < dataGridView1.RowCount; i++)
				{
				  if (!Decimal.TryParse(dataGridView1.Rows[i].Cells[chk[i].Name].Value.ToString(), out num))
					{
					  if (dataGridView1.Rows[i].Cells[dt.Columns[chk[i].Name].ColumnName].Value.ToString() == null || dataGridView1.Rows[i].Cells[dt.Columns[chk[i].Name].ColumnName].Value.ToString() == "")
						{
						}
						else
						{
						MessageBox.Show(dataGridView1.Rows[i].Cells[chk[i].Name].Value.ToString() + "  NOT A DECIMAL!");
						}
					 }
					 else
					 {
					  }
				 }
			 }
		};
	}
