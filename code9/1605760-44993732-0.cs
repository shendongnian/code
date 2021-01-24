    private void FillDataGrid() {
      int curRow = 0;
      foreach (var c in _clienteApp.GetAll()) {
        DataGridViewComboBoxCell cbc = new DataGridViewComboBoxCell();
        foreach (var t in c.Telefones) {
          cbc.Items.Add(t.Numero);
        }
        dataGridViewClientes.Rows.Add(c.Nome, c.Email, c.DataCadastro);
        dataGridViewClientes.Rows[curRow].Cells["Numero"] = cbc;
        curRow++;
      }
    }
