    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack || X.IsAjaxRequest)
            return;
    
        misArtStore.DataSource = new object[] 
        { 
            new { Id = "1", missing = "missing 1" },
            new { Id = "2", missing = "missing 2" },
            new { Id = "3", missing = "missing 3" }
        };
    
        misArtStore.DataBind();
    }
    
    [DirectMethod]
    public string GetGrid(Dictionary<string, string> parameters)
    {
        GridPanel grid = new GridPanel
        {
            Height = 200,
            EnableColumnHide = false,
            Store =
            {
                new Store
                {
                    Model = 
                    {
                        new Model 
                        {
                            IDProperty = "Siteid",
                            Fields = { new ModelField("Siteid"), new ModelField("Site") }
                        }
                    },
                    DataSource = new object[] 
                    { 
                        new { Siteid = "1", Site = "Site 1" },
                        new { Siteid = "2", Site = "Site 2" }
                    }
                }
            },
            ColumnModel =
            {
                Columns = { new Column { Text = "Site", DataIndex = "Site", Width = 150 } }
            }
        };
    
        return ComponentLoader.ToConfig(grid);
    }
