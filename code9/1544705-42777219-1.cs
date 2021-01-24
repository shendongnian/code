	dataGridView1.ColumnCount = 2;
	dataGridView1.Columns[0].Name = "Status";
	dataGridView1.Columns[1].Name = "Country";
	DataGridViewLinkColumn dgvLink = new DataGridViewLinkColumn();
	dgvLink.UseColumnTextForLinkValue = true;
	dgvLink.LinkBehavior = LinkBehavior.SystemDefault;
	dgvLink.HeaderText = "Link Data";
	dgvLink.Name = "SiteName";
	dgvLink.LinkColor = Color.Blue;
	dgvLink.TrackVisitedState = true;
	dgvLink.UseColumnTextForLinkValue = false;
	dataGridView1.Columns.Add(dgvLink);
	dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
	for (int i = 0; i < countriesCodes.Length; i++) {
		var countryName = codeToFullNameMap[countriesCodes[i]];
		string[] row = new string[] { "Ready", countryName, lines[i] };
		dataGridView1.Rows.Add(row);
	}
