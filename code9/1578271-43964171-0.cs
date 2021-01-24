     protected void Page_Load(object sender, EventArgs e) { 
        if (!Page.IsPostBack) {
           loadgrid(); 
        }
     }
     private void loadgrid() {
     con.Open(); 
     cmd.CommandText = "SELECT TOP 4 * FROM [Question] ORDER BY NEWID()"; 
     cmd.Connection = con;
     SqlDataAdapter ad = new SqlDataAdapter(cmd); 
     DataTable dt = new DataTable();
     ad.Fill(dt);
     GridView1.DataSource = dt; 
     GridView1.AllowPaging = true; 
     GridView1.DataBind();
     }
