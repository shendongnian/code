    public void Eliminar() {
      List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
      foreach (DataGridViewRow row in dGVProductos.Rows) {
        if (!row.IsNewRow) {
          if (Convert.ToBoolean(row.Cells["SelectdGV"].Value) == true) {
            rows_with_checked_column.Add(row);
            MessageBox.Show("Row: " + row.Cells[0].Value + ", " + row.Cells[1].Value + ", " + row.Cells[2].Value);
          }
        }
      }
      // Do what you want with the check rows
    }
