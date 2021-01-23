        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try {
        query = "SELECT * FROM products where stock_status = @stock_status and status = @status";
        string conString = ConfigurationManager.ConnectionStrings("conio").ConnectionString;
        MySqlConnection con = new MySqlConnection(conString);
        MySqlCommand cmd = new MySqlCommand(query);
        cmd.Parameters.AddWithValue("@stock_status", "Ready Stock");
        cmd.Parameters.AddWithValue("@status", "active");
        con.Open();
        MySqlDataAdapter da = new MySqlDataAdapter();
        cmd.Connection = con;
        da.SelectCommand = cmd;
        DataTable dt = new DataTable();
        da.Fill(dt);
        ViewState("Data") = dt;
        products.DataSource = dt;
        products.DataBind();
        catHeading.Text = "Products In Ready Stock";
        itemCount.Text = dt.Rows.Count.ToString;
        catSliderHeader.Text = "Categories";
        Page.Title = "Ready Stock Products" + " | BrandSTIK";
        con.Close();
    } catch (Exception ex) {
        Response.Write(ex);
    }
            }
        }
