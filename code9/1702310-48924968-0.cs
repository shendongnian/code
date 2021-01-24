    private BindingSource indexBind = new BindingSource();
    protected void GridView1_RowCommand
    (object sender, GridViewCommandEventArgs e)
    {
      SqlConnection conn = new 
      SqlConnection(ConfigurationManager.ConnectionStrings["EMConStr"].
      ConnectionString);
        conn.Open();
        if (e.CommandName == "AddToCart")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            indexBind.DataSource = index;
            //how to pass this index to "protected void Save(object sender, 
     EventArgs e)"?
        }
        conn.Close();
     }
    protected void Save(object sender, EventArgs e)
    { 
         int index = 
         Convert.ToInt32(indexBind.DataSource);
        //label1.text = index
    }
