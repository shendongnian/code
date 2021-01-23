    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
  
        //or
        if (!IsPostBack)
        {
            BindGrid();
        }
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
