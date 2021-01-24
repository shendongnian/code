    foreach (DataGridViewRow Row in dataGridView1.Rows) {
      DataRowView drv = (DataRowView)Row.DataBoundItem;
      if (drv != null) {
        if (drv.Row["Primary Onc"].ToString() == "JMK") {
          Row.DefaultCellStyle.BackColor = Color.Green;
        }
        else {
          if (drv.Row["Primary Onc"].ToString() == "DBF") {
            Row.DefaultCellStyle.BackColor = Color.Orange;
          }
          else {
            Row.DefaultCellStyle.BackColor = Color.White;
          }
        }
      }
    }
