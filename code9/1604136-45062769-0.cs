    tableLayoutPanel1.SuspendLayout();
    int i;
	while ((i = tableLayoutPanel1.Controls.Count) >= 2) {
		tableLayoutPanel1.Controls[--i].Dispose();
		tableLayoutPanel1.Controls[--i].Dispose();
		tableLayoutPanel1.Controls[--i].Dispose();
	}
	while (tableLayoutPanel1.RowStyles.Count > 0) {
			tableLayoutPanel1.RowStyles.RemoveAt(tableLayoutPanel1.RowStyles.Count - 1);
	}
	tableLayoutPanel1.RowCount = 0;
    for(int i=0; i<inp.Count; i++){
        if (i > inp.Count - 6) {
		    tableLayoutPanel1.ResumeLayout();
	    }
    //...
    }
