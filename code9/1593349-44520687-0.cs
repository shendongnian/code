    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
            x[0] = new Random().Next(100);
    }
    protected void bGenerate_Click(object sender, EventArgs e)
    {
        limit++;
        x[limit] = new Random().Next(100);
    }
