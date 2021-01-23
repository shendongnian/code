        String query = "select * from bug order by id desc;";
        String Status = null;                     
        DataTable dt = connection.retrieve(query);
        for (int i = 0; i < dataGridViewDashboard.Rows.Count; i++)
        {
           if (dataGridViewDashboard.Rows[i].IsNewRow)
                    continue;
            Status = dataGridViewDashboard.Rows[i].Cells[8].Value.ToString();
            if (Status == "Incomplete")
            {
                dataGridViewDashboard.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            }
            else
            {
                dataGridViewDashboard.Rows[i].DefaultCellStyle.BackColor = Color.Green;
            }
        }
