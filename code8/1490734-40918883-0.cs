    protected void Page_Load(object sender, EventArgs e)
    {
        DropDownList1.DataSource = SqlDataSource1;
        DropDownList1.DataBind()
  
        ListItem itemToRemove = DropDownList1.Items.FindByText("compiler");   
        if (itemToRemove != null)
        {
            DropDownList1.Items.Remove(itemToRemove);
        }
    }
