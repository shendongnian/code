    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView row = e.Row.DataItem as DataRowView;
        TableCell cantidadesCell = e.Row.Cells[0];
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string[] cantidades = row["CANTIDADES"].ToString().Split(',');
            for (int i = 0; i < cantidades.Length; i++)
            {
                var cantidadTextBox = new TextBox();
                cantidadTextBox.ID = "txtCantidad" + i;
                cantidadTextBox.Text = cantidades[i];
                cantidadTextBox.Width = 50;
                cantidadTextBox.CssClass = "txtCantidad";
                cantidadesCell.Controls.Add(cantidadTextBox);
            }
        }
    }
