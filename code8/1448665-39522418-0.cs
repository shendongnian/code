    protected void Page_Init(object sender, EventArgs e)
    {
      this.Page.LoadComplete += new EventHandler(this.Page_LoadComplete);
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
      this.DataBind();
    }
    
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
      this.ddl.SelectedValue = "B";
    }
    
    protected void b_Click(object sender, EventArgs e)
    {
      Console.WriteLine("Updated");
    }
