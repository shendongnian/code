    Int64 cellValue = 0;
    foreach (DataGridViewRow DG in dtgrdUCBuyInvoices.Rows) {
      if (!DG.IsNewRow && DG.Cells["iRemaining"].Value != null) {
        Int64.TryParse(DG.Cells["iRemaining"].Value.ToString(), out cellValue);
        if (cellValue != 0) {
          DG.Cells["iRemaining"].Style.BackColor = Color.Red;
          DG.Cells["iRemaining"].Style.ForeColor = Color.White;
        }
      }
    }
