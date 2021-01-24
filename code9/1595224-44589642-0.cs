    protected void Page_Load(object sender, EventArgs e)
    {
        //check if it is a postback
        if (!Page.IsPostBack)
        {
            //create a new table
            DataTable vendas = new DataTable();
            //add some columns
            vendas.Columns.Add("Nome");
            vendas.Columns.Add("Morada");
            //add the datatable to the viewstate
            ViewState["vendas"] = vendas;
        }
        else
        {
            //check if the viewstate exits and cast it back to a datatable
            if (ViewState["vendas"] != null)
            {
                vendas = ViewState["vendas"] as DataTable;
            }
        }
    }
