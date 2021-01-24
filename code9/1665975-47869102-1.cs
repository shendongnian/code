    protected void Page_Load(object sender, EventArgs e)
    {
        store.DataSource = new object[] 
        { 
            new { Field1 = "Row 1" },
            new { Field1 = "Row 2" },
            new { Field1 = "Row 3" }
        };
    
        store.DataBind();
    
        RowSelectionModel selectionModel = grid.GetSelectionModel() as RowSelectionModel;
        selectionModel.SelectedIndex = 0; // Select first row
    }
