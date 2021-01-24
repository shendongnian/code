    public ActionResult retorna_excel_FetsVinculats2()
    {
         DataTable dt1 = new DataTable("Table1");
         dt1.Columns.Add("Num", typeof(Int32));
         dt1.Columns.Add("date", typeof(string));
         dt1.Columns.Add("name", typeof(string));
         dt1.Columns.Add("product1a", typeof(Int32));
         dt1.Columns.Add("product1b", typeof(Int32));
         dt1.Columns.Add("total1", typeof(Int32));
         dt1.Columns.Add("product2a", typeof(Int32));
         dt1.Columns.Add("product2b", typeof(Int32));
         dt1.Columns.Add("product2c", typeof(Int32));
         dt1.Columns.Add("total2", typeof(Int32));
         object[] o1 = { 1, "10/10/2017", "name 1", 1, 2, 3, 1, 1, 1, 3 };
         object[] o2 = { 2, "20/10/2017", "name 2", 2, 2, 4, 2, 1, 2, 5 };
         object[] o3 = { 3, "15/08/2017", "name 3", 1, 3, 4, 4, 0, 0, 4 };
            
         dt1.Rows.Add(o1);
         dt1.Rows.Add(o2);
         dt1.Rows.Add(o3);
         GridView grid = new GridView();                    
         grid.DataSource = dt1;
         grid.DataBind();
         List<Tuple<string, int, bool, HorizontalAlign>> list_header = new List<Tuple<string, int, bool, HorizontalAlign>>();
         list_header.Add(new Tuple<string, int, bool, HorizontalAlign>("", 3, false, HorizontalAlign.Center));
         list_header.Add(new Tuple<string, int, bool, HorizontalAlign>("Head Products 1", 3, true, HorizontalAlign.Center));
         list_header.Add(new Tuple<string, int, bool, HorizontalAlign>("Head Products 2", 4, true, HorizontalAlign.Center));            
         get_header_table(grid, list_header);
         Response.ClearContent();
         Response.Buffer = true;
         Response.AddHeader("content-disposition", "attachment; filename=ExportFetsVinculats.xls");
         Response.ContentType = "application/ms-excel";
         Response.Charset = "";
         StringWriter sw = new StringWriter();
         HtmlTextWriter htw = new HtmlTextWriter(sw);
         grid.RenderControl(htw);
         Response.Output.Write(sw.ToString());
         Response.Flush();
         Response.End();
         return Content("");
    }
    
    private void get_header_table(GridView grid, List<Tuple<string, int, bool, HorizontalAlign>> list_header)
    {
        GridView HeaderGrid = grid;
        GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableCell HeaderCell = new TableCell();
        foreach (Tuple<string, int, bool, HorizontalAlign> item in list_header)
        {
            HeaderCell = new TableCell();
            HeaderCell.Text = item.Item1;
            HeaderCell.ColumnSpan = item.Item2;
            HeaderCell.Font.Bold = item.Item3;
            HeaderCell.HorizontalAlign = item.Item4;
            HeaderGridRow.Cells.Add(HeaderCell);
        }
        HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);
    }
