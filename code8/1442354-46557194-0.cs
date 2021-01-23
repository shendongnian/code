    dgvTrucksMaster.SuspendLayout();
    dgvTrucksMaster.DataSource = calendar.FailureCalendarDetails.OrderBy(x => x.MachineFullName).ToList();
    
    foreach (DataGridViewRow row in dgvTrucksMaster.Rows)
    {
        if (Convert.ToDouble(row.Cells["Decade1Hours"].Value) > 0)
        {
            row.Cells["Decade1Hours"].Style.BackColor = Color.LightGreen;
        }
    
        if (Convert.ToDouble(row.Cells["Decade1Hours"].Value) < 0)
        {
            // row.DefaultCellStyle.BackColor = Color.LightSalmon;
            row.Cells["Decade1Hours"].Style.BackColor = Color.LightSalmon;
        }
    
        if (Convert.ToDouble(row.Cells["Decade2Hours"].Value) > 0)
        {
            row.Cells["Decade2Hours"].Style.BackColor = Color.LightGreen;
        }
    
        if (Convert.ToDouble(row.Cells["Decade2Hours"].Value) < 0)
        {
            // row.DefaultCellStyle.BackColor = Color.LightSalmon;
            row.Cells["Decade2Hours"].Style.BackColor = Color.LightSalmon;
        }
    
        if (Convert.ToDouble(row.Cells["Decade3Hours"].Value) > 0)
        {
            row.Cells["Decade3Hours"].Style.BackColor = Color.LightGreen;
        }
    
        if (Convert.ToDouble(row.Cells["Decade3Hours"].Value) < 0)
        {
            // row.DefaultCellStyle.BackColor = Color.LightSalmon;
            row.Cells["Decade3Hours"].Style.BackColor = Color.LightSalmon;
        }
    
        if (Convert.ToDouble(row.Cells["DecadeMonthHours"].Value) > 0)
        {
            row.Cells["DecadeMonthHours"].Style.BackColor = Color.LightGreen;
        }
    
        if (Convert.ToDouble(row.Cells["DecadeMonthHours"].Value) < 0)
        {
            // row.DefaultCellStyle.BackColor = Color.LightSalmon;
            row.Cells["DecadeMonthHours"].Style.BackColor = Color.LightSalmon;
        }
    
        for (int i = 0; i < 61; i++)
        {
            if (Convert.ToDouble(row.Cells[string.Format("D{0}", i + 1)].Value) < 0)
            {
                row.Cells[string.Format("D{0}", i + 1)].Style.BackColor = Color.LightSalmon;
            }
    
    
            if (Convert.ToDouble(row.Cells[string.Format("D{0}", i + 1)].Value) > 0)
            {
                row.Cells[string.Format("D{0}", i + 1)].Style.BackColor = Color.LightGreen;
            }
        }
    }
    
    dgvTrucksMaster.ResumeLayout();
