    private int[] daysInMonths;
    private void Form1_Load(object sender, EventArgs e)
    {
        int year = DateTime.Now.Year;
        daysInMonths = new int[12];
        // Add a column for each day of the year; where
        // column name = the date (creates all unique column names)
        // column header text = the numeric day of the month
        for (int month = 1; month <= 12; month++)
        {
            daysInMonths[month - 1] = DateTime.DaysInMonth(year, month);
            // for days 1-31, 1-29, etc.
            for (int day = 1; day <= daysInMonths[month - 1]; day++)
            {
                DateTime date = new DateTime(year, month, day);
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
                {
                    Name = date.ToString(),
                    HeaderText = day.ToString(),
                    Width = 20
                };
                this.dataGridView1.Columns.Add(col);
            }
        }
        // add some default rows
        for (int r = 0; r < 4; r++)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(this.dataGridView1);
            row.HeaderCell.Value = $"Project {r + 1}";
            this.dataGridView1.Rows.Add(row);
        }
        this.dataGridView1.AllowUserToAddRows = false;
        this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
        this.dataGridView1.ColumnHeadersHeight = this.dataGridView1.ColumnHeadersHeight * 2;
        this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
        this.dataGridView1.Paint += DataGridView1_Paint;
        this.dataGridView1.Scroll += DataGridView1_Scroll;
        this.dataGridView1.ColumnWidthChanged += DataGridView1_ColumnWidthChanged;
        this.dataGridView1.Resize += DataGridView1_Resize;
    }
