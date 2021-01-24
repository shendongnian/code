    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ...
            hfSelCat.Value = Request.Form[hfSelCat.UniqueID];
        }
    }
