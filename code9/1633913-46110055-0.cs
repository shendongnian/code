        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = SqlDataSource1;
                GridView1.DataBind();
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.DataSource = SqlDataSource1;
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
            TextBox txt = GridView1.Rows[e.NewEditIndex].FindControl("TextBox1") as TextBox;
            string name = txt.Text;
         }
