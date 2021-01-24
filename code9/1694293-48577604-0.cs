      protected void Add_Click(object sender, EventArgs e)
            {
    
                
                string constr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
               
                //SqlCommand cmd = new SqlCommand("insert into Student(RegNo,Name,Address,CreatedTime) values(RegNo,Name,Address,Getdate())");
                SqlCommand cmd = new SqlCommand("insert into    Student(RegNo,Name,Address,CreatedTime)values(@RegNo,@Name,@Address,Getdate())");
                cmd.Parameters.AddWithValue("@RegNo", RegNo);
                cmd.Connection = con;
                con.Open();
    
                cmd.ExecuteNonQuery();
                con.Close();
    
            }
