	for (int i = 0; i < countriesCodes.Length; i++)
	{
		dataGridView1.ColumnCount = 2;
		dataGridView1.Columns[0].Name = "Status";
		dataGridView1.Columns[1].Name = "Country";
		var countryName = codeToFullNameMap[countriesCodes[i]];
		string[] row = new string[] { "Ready", countryName };
		dataGridView1.Rows.Add(row);
		DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
		dgvLink.UseColumnTextForLinkValue = true;
		dgvLink.LinkBehavior = LinkBehavior.SystemDefault;
		dgvLink.HeaderText = "Link Data";
		dgvLink.Name = "SiteName";
		dgvLink.LinkColor = Color.Blue;
		dgvLink.TrackVisitedState = true;
		dgvLink.Text = lines[i];
		dgvLink.UseColumnTextForLinkValue = true;
		dataGridView1.Columns.Add(dgvLink);
	}
