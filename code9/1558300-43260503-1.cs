    protected void btAdd_Click(object sender, EventArgs e)
            {
                Table ta = tablaPed;
                
                TableRow t = new TableRow();
                TableCell c = new TableCell();
                c.Text = "asdfasdas";
                t.Cells.Add(c);
    
                TableCell c2 = new TableCell();
                c2.Text = "asa";
                t.Cells.Add(c2);
    
                ta.Rows.Add(t);
                List<TableRow> listTableRows = Session["TA"] != null ? (List<TableRow>)Session["TA"] : new List<TableRow>();
                listTableRows.Add(t);
                Session["TA"] = listTableRows;
            }
