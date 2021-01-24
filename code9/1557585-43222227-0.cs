    protected void btAgregaT_Click(object sender, EventArgs e)
    {
        TableRow t = tablaPed.TableRow();
        TableCell c = new TableCell();
        c.Text = DDLArticulos.SelectedItem.ToString();
        t.Cells.Add(c);
        TableCell c2 = new TableCell();
        c2.Text = TBCantidad.Text;
        t.Cells.Add(c2);
        tablaPed.Rows.Add(t);  
    }
