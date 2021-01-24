        public static TableLayoutPanel AddTitleToChart(Control chart,string title, System.Drawing.Font titleFont)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.Font = titleFont;
            label.Location = new System.Drawing.Point(3, 0);
            label.Name = "label1";
            label.Size = new System.Drawing.Size(1063, 55);
            label.TabIndex = 0;
            label.Text = title;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.BackColor = chart.BackColor;
            chart.Dock = System.Windows.Forms.DockStyle.Fill;
            
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.BackColor = System.Drawing.Color.White;
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1069F));
            tableLayoutPanel.Controls.Add(label, 0, 0);
            tableLayoutPanel.Controls.Add(chart, 0, 1);
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel1";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel.Size = new System.Drawing.Size(1069, 662);
            tableLayoutPanel.TabIndex = 2;
            return (tableLayoutPanel);
        }
