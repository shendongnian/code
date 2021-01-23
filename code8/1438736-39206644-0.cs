    private void btnDeleteDjelatnik_Click(object sender, EventArgs e)
            {
                int index = djelatnikDataGrid.SelectedRows[0].Index;
                int idDjelatnik = -1;
                Int32.TryParse(djelatnikDataGrid["IDDjelatnik", index].Value.ToString(), out idDjelatnik);
                r.DeleteDjelatnik(idDjelatnik);
                djelatnikDataGrid.Rows.RemoveAt(index);
            }
