    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBoxList1.AutoPostBack = true;
        List<ListItem> selectedItems = Session["SelectedItems"] as List<ListItem>;
        if(selectedItems == null)
        {
            Session["SelectedItems"] = new List<ListItem>();
        }
    }
