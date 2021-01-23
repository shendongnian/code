      protected void Page_Load(object sender, EventArgs e)
      {
            if (!IsPostBack)
            {
                //Some stuff
                grid.DataSource = sourceTable;
                grid.DataBind();
                //Other stuff
            }
      }
