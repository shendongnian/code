    var tableLayoutPanel = new TableLayoutPanel
    {
        Dock = DockStyle.Fill,
        RowCount = 2,
        ColumnCount = 2
    };
    tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
    tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
    tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
    tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
    tableLayoutPanel.Controls.Add(new Button { Dock = DockStyle.Fill });
    tableLayoutPanel.Controls.Add(new Button { Dock = DockStyle.Fill });
    tableLayoutPanel.Controls.Add(new Button { Dock = DockStyle.Fill });
    tableLayoutPanel.Controls.Add(new Button { Dock = DockStyle.Fill });
    yourForm.Controls.Add(tableLayoutPanel);
