    protected void Page_Load(object sender, EventArgs e)
     {
        List<String> itemlist = new List<string>();
        itemlist.Add("Drink water");
        itemlist.Add("Sleep more");
        itemlist.Add("Drink tea");
        itemlist.Add("Drink water");
        itemlist.Add("Exercise more");
        itemlist.Add("Eat healthier");
        itemlist.Add("Smile");
        itemlist.Add("Do Yoga");
        ddlItems.DataSource = itemlist;
        ddlItems.DataBind();
    }
    
