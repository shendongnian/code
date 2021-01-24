    private void filter_color_CheckedChanged2(object sender, EventArgs e) {
      CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[mproductDataGridView.DataSource];
      currencyManager1.SuspendBinding();
      if (filter_color.Checked)
        FilterRows(Color.Yellow);
      else
        UnFilterRows();
      currencyManager1.ResumeBinding();
    }
    private void FilterRows(Color fColor) {
      foreach (DataGridViewRow item in mproductDataGridView.Rows) {
        if (!item.IsNewRow) {
          if (item.DefaultCellStyle.BackColor != fColor) {
            item.Visible = false;
          }
        }
      }
    }
    private void UnFilterRows() {
      foreach (DataGridViewRow item in mproductDataGridView.Rows) {
        item.Visible = true;
      }
    }
