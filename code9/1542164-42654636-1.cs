    //create a list with keyvalue pairs to hold the removed items
    public static List<KeyValuePair<int, string>> itemsRemoved = new List<KeyValuePair<int, string>>();
    protected void Page_Load(object sender, EventArgs e)
    {
        //check if the session with the removed items exists and if so cast back to a list
        if (Session["itemsRemoved"] != null)
        {
            itemsRemoved = Session["itemsRemoved"] as List<KeyValuePair<int, string>>;
        }
        //bind the gridview
        if (!Page.IsPostBack)
        {
            GridView1.DataSource = Common.LoadFromDB();
            GridView1.DataBind();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a normal datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList LCList = (e.Row.FindControl("LCList") as DropDownList);
            //create an array with the dropdown option for easier looping
            string[] listItems = new string[] { "casual Leave", "sick Leave", "LOP" };
            for (int i = 0; i < listItems.Length; i++)
            {
                bool wasRemoved = false;
                //check if the listitem was remove for this row
                for (int j = 0; j < itemsRemoved.Count; j++)
                {
                    if (e.Row.RowIndex == itemsRemoved[j].Key && listItems[i] == itemsRemoved[j].Value)
                    {
                        wasRemoved = true;
                    }
                }
                //if not removed, add it to the dropdownlist
                if (wasRemoved == false)
                {
                    LCList.Items.Insert(LCList.Items.Count, new ListItem(listItems[i]));
                }
            }
        }
    }
    protected void LCList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //cast the sender back to a dropdownlist
        DropDownList LCList = sender as DropDownList;
        //get tne namingcontainer from the dropdownlist to get the rownumber
        GridViewRow row = (GridViewRow)LCList.NamingContainer;
        int rowIndex = row.RowIndex;
        //create a new keyvalue pair with the correct rowindex and selected value
        KeyValuePair<int, string> kv = new KeyValuePair<int, string>(rowIndex, LCList.SelectedValue);
        //add it to the list with removals
        itemsRemoved.Add(kv);
        //remove from the dropdownlist immediately
        LCList.Items.RemoveAt(LCList.SelectedIndex);
    }
