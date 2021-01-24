    public void Color()
        {
            foreach (DataGridViewRow row in ProductServicesDataGrid.Rows)
                if (Convert.ToInt32(row.Cells[5].Value) > Convert.ToInt32(row.Cells[6].Value))
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
                else if (Convert.ToInt32(row.Cells[5].Value) < Convert.ToInt32(row.Cells[6].Value))
                {
                    row.DefaultCellStyle.ForeColor = Color.Yellow;
                }
                else if (Convert.ToInt32(row.Cells[5].Value) == 0 && Convert.ToInt32(row.Cells[6].Value) > Convert.ToInt32(row.Cells[5].Value))
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                }
        }
