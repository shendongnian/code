    foreach (DataGridViewRow Row in datagridviewTreatmentPrep.Rows) {
      DataRowView drv = (DataRowView)Row.DataBoundItem;
      if (drv.Cells["Primary Onc"].Value.ToString() == "JMK") {
        Row.DefaultCellStyle.BackColor = Color.Green;
      }
      if (drv.Cells["Primary Onc"].Value.ToString() == "DBF") {
        Row.DefaultCellStyle.BackColor = Color.Orange;
      }
      else {
        Row.DefaultCellStyle.BackColor = Color.White;
      }
    }
