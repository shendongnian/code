        protected void Page_Load(object sender, EventArgs e)
        {
            var tbl = new DataTable();
            tbl.Columns.Add("Ps", typeof(Int32));
            tbl.Columns.Add("P", typeof(string));
            tbl.Columns.Add("T", typeof(string));
            var r = tbl.NewRow();
            r[0] = 99;
            r[1] = "Hey";
            r[2] = "USA";
            tbl.Rows.Add(r);
            ListView1.DataSource = tbl;
            ListView1.DataBind();
            var ptbl = (HtmlTable)ListView1.FindControl("ptbl");
            ptbl.Style.Add("background-color", "red");
        }
