    protected void Button1_Click(object sender, EventArgs e)
            {
                GridView1.DataSource = null;
               GridView1.DataBind(); 
    
                connect = new SqlConnection(@"Data Source=LP12;Initial Catalog=Data;Integrated Security=True");
                connect.Open();
    
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "SELECT DrukSensor, FlowSensor                
    + " FROM SysteemSensorInfo";
    
                DataSet ds = new DataSet();
                new SqlDataAdapter(cmd).Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                GridView1.AutoGenerateColumns = false;
            }
