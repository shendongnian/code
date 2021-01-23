    private void gridUsuarios_CellFormatting(object sender,System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
    {
        if (this.gridUsuarios.Columns[e.ColumnIndex].Name == "status")
        {
            if (e.Value != null)
            {
                e.Value.ToString() == "1" ? e.Value = "Active" : e.Value = "Inactive";
                e.FormattingApplied = true;
            }
        }
    }
