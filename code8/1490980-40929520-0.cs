    private Delegate _FileSelected;
    public Delegate FileSelected
    {
        set { _FileSelected = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (FileUpload1.HasFile)
            {
                //invoke the command in the parent
                _FileSelected.DynamicInvoke(FileUpload1.FileName);
            }
        }
