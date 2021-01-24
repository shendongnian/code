    protected void empsave(object sender, EventArgs e)
    {
      connection();
      query =  "studentEntryView";          //Stored Procedure name 
      SqlCommand com = new SqlCommand(query, con);  //creating  SqlCommand  object
      com.CommandType = CommandType.StoredProcedure;  //here we declaring command type as stored Procedure
    
      /* adding paramerters to  SqlCommand below *\
      com.Parameters.AddWithValue("@Action", HiddenField1.Value).ToString();//for ing hidden value to preform insert operation
      com.Parameters.AddWithValue("@FName",TextBox1.Text.ToString());        //first Name
      com.Parameters.AddWithValue("@Mname ", TextBox2.Text.ToString());     //middle Name
      com.Parameters.AddWithValue("@LName ",TextBox3.Text.ToString());       //Last Name
      com.ExecuteNonQuery();                     //executing the sqlcommand
      Label1.Visible = true;
      Label1.Text = "Records are Submitted Successfully";
    }
