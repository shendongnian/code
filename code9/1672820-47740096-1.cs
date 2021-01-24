    protected void Repeaterp_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //check if it is the second row
        if (e.Item.ItemIndex == 1)
        {
            //find the gridviews in the repeater item using findcontrol
            GridView gv1 = e.Item.FindControl("GridView1") as GridView;
            GridView gv2 = e.Item.FindControl("GridView2") as GridView;
            //create a dummy datatable for this demo
            DataTable table = new DataTable();
            table.Columns.Add("Col1", typeof(int));
            table.Columns.Add("Col2", typeof(string));
            table.Columns.Add("Col3", typeof(string));
            //add some rows to the table
            table.Rows.Add(0, "Row 1", "AAA");
            table.Rows.Add(1, "Row 2", "BBB");
            table.Rows.Add(2, "Row 3", "CCC");
            //bind the data to the gridviews in the second row
            gv1.DataSource = table;
            gv2.DataSource = table;
            gv1.DataBind();
            gv2.DataBind();
        }
    }
