    protected void btAdd_Click(object sender, EventArgs e)
    {
            Table ta = tablaPed;
            TableRow t = new TableRow();
            TableCell c = new TableCell();
            List<TableRow> listTableRows = Session["TA"] != null ? (List<TableRow>)Session["TA"] : new List<TableRow>();
            c.Text = DDLArticulos.SelectedValue.ToString():
            t.Cells.Add(c);
            TableCell c2 = new TableCell();
            c2.Text = TBCantidad.Text:
            t.Cells.Add(c2);
            ta.Rows.Add(t);
            listTableRows.Add(t);
            Session["TA"] = listTableRows;
    }
