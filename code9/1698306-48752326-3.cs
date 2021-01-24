    if(!dgvVacationCalendar.Columns.Contains("ProcessColumn")) {
        DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn();
        cb.HeaderText = "Process";
        cb.Width = 100;
        dgvVacationCalendar.Columns.Insert(2, cb);
    }
