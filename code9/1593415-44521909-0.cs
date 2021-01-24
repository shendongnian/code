            Dictionary<string, string> startShapes = new Dictionary<string, string>();
            for(int i=0;i<20;i++)
                startShapes.Add("Shape " +i, "Shape " +i);
            int row = 0;
            int col = 0;
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel1.RowCount= 0;
            tableLayoutPanel1.ColumnCount = 1;
            foreach (var kvp in startShapes)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel1.RowCount++;
                RadioButton rdb = new RadioButton();
                rdb.Text = string.IsNullOrEmpty(kvp.Value) ? kvp.Key : kvp.Value;
                rdb.Size = new Size(100, 30);
                rdb.CheckedChanged += (s, ee) =>
                {
                    var r = s as RadioButton;
                    if (r.Checked)
                        this.selectedString = r.Text;
                };
                tableLayoutPanel1.Controls.Add(rdb, col, row);
                row++;
                if (row == 5)
                {
                    col++;
                    row = 0;
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    tableLayoutPanel1.ColumnCount++;
                }
            }
