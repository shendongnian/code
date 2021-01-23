    using(SqlConnection connect = new SqlConnection("Data Source=THEBEAST;Initial Catalog=newregDB;Integrated Security=True;Pooling=False"))
    using(SqlCommand cmd = new SqlCommand("SELECT [firstname], [dob], [ChildID] FROM [children]", connect))
    {
        connect.Open();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt; //give your gridview name here
        GridView1.DataBind();//give your gridview name here
    }
