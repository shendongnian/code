     private void BindGrid()
    {
    	
       using (SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\PROJECT SEM6\Online Tours and Travels\App_Data\ToursandTravels.mdf;Integrated Security=True;User Instance=True"))
        {
        
        using (SqlCommand cmd = new SqlCommand("SELECT packagename,name, gender,mobileno,email,noofdays,child,adults,statusfield FROM enquiry"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
