    var combBoxes = this.Controls.OfType<ComboBox>()
                        .Where(x => x.Name.StartsWith("comboBox")).ToList();
	for (int i = 0; i < combBoxes.Count; i++)
	{
		combBoxes[i].Items.Add(crvIn[i + 2]);
	}
