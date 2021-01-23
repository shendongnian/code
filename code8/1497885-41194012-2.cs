    protected void Page_Load(object sender, EventArgs e)
    {
      grid1.DataSource = getDataSet();
      grid1.DataBind();      
    }
    private List<Object> getDataSet()
    {
        if (Session["myGridViewData"] == null)
            Session["myGridViewData"] = new List<employee>();            
     
        return (List<Object>)Session["myGridViewData"];
    }
    protected void addNewRowButton_Click(object sender, EventArgs e)
    {
        List<Object> list = (List<Object>)Session["myGridViewData"];       
        list.Add(new Object ());
        Session["myGridViewData"] = list;
    }
