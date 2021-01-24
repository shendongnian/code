    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillMainDll();
        if (!IsPostBack || GridView1.Rows.Count > 0)
            BindGrid();
    }
    private void FillMainDll()
    {
        select1.DataSource = new int[] { 1, 2, 3 };
        select1.DataBind();
    }
    private void BindGrid()
    {
        var dt = new DataTable();
        dt.Columns.Add(new DataColumn("ID", typeof(Int32)));
        dt.Columns.Add(new DataColumn("Name", typeof(string)));
        for (int i = 1; i < 5; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = "Name - " + i.ToString();
            dt.Rows.Add(dr);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var myDDL = new DropDownList();
            myDDL.ID = "myDDL";
            myDDL.DataSource = GetGridRowDdlData();
            myDDL.DataBind();
            e.Row.Cells[1].Controls.Add(myDDL);
        }
    }
    private IEnumerable<string> GetGridRowDdlData()
    {
        var data = new List<string>();
        for (int i = 1; i < 4; i++)
        {
            data.Add("Name - " + i * int.Parse(select1.SelectedValue));
        }
        return data;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var sb = new System.Text.StringBuilder();
        foreach (GridViewRow row in GridView1.Rows)
        {
            var myDDL = row.FindControl("myDDL") as DropDownList;
            if (myDDL != null)
            {
                sb.AppendFormat("{0}<br/>", myDDL.SelectedValue);
            }
        }
        Response.Write(sb.ToString());
    }
