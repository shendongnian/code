    DataTable TempDT = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateDataTable();
        if (!IsPostBack)
        {
            GridView_Outer.DataSource = TempDT;
            GridView_Outer.DataBind();
        }
    }
    // create DataTable
    public void CreateDataTable()
    {
        TempDT = new DataTable();
        TempDT.Columns.Add("Label_Outer");
        TempDT.Columns.Add("Label_Inner");
        TempDT.Columns.Add("TextBox_Inner");
        TempDT.Rows.Add("OuterLabel", "InnerLabel", "");
        TempDT.Rows.Add("OuterLabel", "InnerLabel", "");
        // store DataTable into ViewState to prevent data loss on PostBack
        ViewState["DT"] = TempDT;
    }
    // Calls Outer GridView on Data Binding
    protected void GridView_Outer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check if gridview row is not in edit mode
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get Outer GrridView 's controls
            Label Label_Outer = (Label)e.Row.FindControl("Label_Outer");
            GridView GridView_Inner = (GridView)e.Row.FindControl("GridView_Inner");
            // get DataTable from ViewState and set to Inner GridView
            GridView_Inner.DataSource = (DataTable)ViewState["DT"];
            GridView_Inner.DataBind();
        }
    }
    // Calls Inner GridView on Data Binding
    protected void GridView_Inner_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check if gridview row is not in edit mode
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get Outer GrridView 's controls
            DropDownList DropDownList_Inner = (DropDownList)e.Row.FindControl("DropDownList_Inner");
            // Create a DataTable to Bind data for DropDownlist
            DataTable TempDDLDT = new DataTable();
            TempDDLDT.Columns.Add("ItemText");
            TempDDLDT.Columns.Add("ItemValue");
            TempDDLDT.Rows.Add("ItemText1", "ItemValue1");
            TempDDLDT.Rows.Add("ItemText2", "ItemValue2");
            // bind DataTable to the DropDownList
            DropDownList_Inner.DataSource = TempDDLDT;
            DropDownList_Inner.DataTextField = "ItemText";
            DropDownList_Inner.DataValueField = "ItemValue";
            DropDownList_Inner.DataBind();
        }
    }
    // Calls when Inner GridView 's button clicked
    protected void GridView_Inner_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // get Inner GridView 's clicked row
        GridViewRow InnerGridViewRow = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        // get Inner GridView 's controls from clicked row
        TextBox TextBox_Inner = (TextBox)InnerGridViewRow.FindControl("TextBox_Inner");
        DropDownList DropDownList_Inner = (DropDownList)InnerGridViewRow.FindControl("DropDownList_Inner");
        // check if correct button is clicked
        if (e.CommandName == "BtnInnerCmd")
        {
            string DropDownListValue = DropDownList_Inner.SelectedValue;
            string TextBoxValue = TextBox_Inner.Text;
            Label_Result.Text = "DropDownList 's Selected Value is " + DropDownListValue +
                                "<br />TextBox 's Entered Value is " + TextBoxValue;
        }
    }
