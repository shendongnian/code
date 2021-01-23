    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id"), new DataColumn("Name"), new DataColumn("Country") });
            dt.Rows.Add(1, "John Hammond", "United States");
            dt.Rows.Add(2, "Mudassar Khan", "India");
            dt.Rows.Add(3, "Suzanne Mathews", "France");
            dt.Rows.Add(4, "Robert Schidner", "Russia");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //Accessing BoundField Column
        string name = GridView1.SelectedRow.Cells[0].Text;
     
        //Accessing TemplateField Column controls
        string country = (GridView1.SelectedRow.FindControl("lblCountry") as Label).Text;
     
        lblValues.Text = "<b>Name:</b> " + name + " <b>Country:</b> " + country;
    }
