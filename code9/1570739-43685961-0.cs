    private void GetData()
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection("YOUR CONNECTION STRING HERE");
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT * from TABLE1", connection);
        sqlDa.Fill(dt);
        if (dt.Rows.Count > 0)
        {
               TextBox1.Text = dt.Rows[0]["ColumnName1"].ToString(); //Where ColumnName is the Field from the DB that you want to display
               TextBox2.Text = dt.Rows[0]["ColumnName2"].ToString();
               Label1.Text = dt.Rows[0]["ColumnName3"].ToString();
               Label2.Text = dt.Rows[0]["ColumnName4"].ToString();
        }
            connection.Close();
    }
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
    
    
       if (!Page.IsPostBack){
        GetData();
       }
    
    
    }
