    dataGridView1.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=Form;Integrated Security=True";
            con.Open()
            SqlCommand com = new SqlCommand("select * from Form", con);
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt=new DataTable();
            sda.Fill(dt);   
             
            dataGridView1.DataSource = dt;//set it to datatable
            dataGridView1.DataBind();
