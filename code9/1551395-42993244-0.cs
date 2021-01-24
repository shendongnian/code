        protected void btnLink_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(YourConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Properties where Id=@Pid", con);
            cmd.Parameters.AddWithValue("@Pid",Convert.ToInt32(txtPropCode.Text));
            con.Open();
            object id=cmd.ExecuteScalar();
            If((int)id!=-1);
            //it means record exists 
            else
            //The record doesn't exist
        }
