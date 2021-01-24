    DataTable TempDT = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getData();
        }
    }
    // create DataTable 3 x 2
    public void getData()
    {
        TempDT = new DataTable();
        TempDT.Columns.Add("Col1");
        TempDT.Columns.Add("Col2");
        TempDT.Columns.Add("Count");
        TempDT.Rows.Add("Temp", "Temp", 100);
        TempDT.Rows.Add("Temp", "Temp", 100);
        TempDT.Rows.Add("Temp", "Temp", 100);
        // store DataTable into ViewState from lost on PostBack
        ViewState["DT"] = TempDT;
        RepeaterTable.DataSource = TempDT;
        RepeaterTable.DataBind();
    }
    // Calls parent Repeater on Binding Data
    protected void RepeaterTable_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // check Repeater item type is not in edit mode
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataTable dt = new DataTable();
            // get and set DataTable from ViewState
            dt = ViewState["DT"] as DataTable;
                
            Repeater RepeaterTable1 = e.Item.FindControl("RepeaterTable1") as Repeater;
            Repeater RepeaterTable2 = e.Item.FindControl("RepeaterTable2") as Repeater;
            RepeaterTable1.DataSource = dt;
            RepeaterTable1.DataBind();
            RepeaterTable2.DataSource = dt;
            RepeaterTable2.DataBind();
            Panel PanelTextBoxes = e.Item.FindControl("PanelTextBoxes") as Panel;
            Panel PanelTables = e.Item.FindControl("PanelTables") as Panel;
            // show only first structure
            if (e.Item.ItemIndex != 0)
            {
                PanelTextBoxes.Visible = false;
                PanelTables.Visible = false;
            }        
        }
    }
    // Calls child Repeater on Binding Data
    protected void RepeaterTable1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // check Repeater item type is not in edit mode
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //.. here is code when child repeater is binding
        }
    }
    // Calls child Repeater on Binding Data
    protected void RepeaterTable2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // check Repeater item type is not in edit mode
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //.. here is code when child repeater is binding
        }
    }
