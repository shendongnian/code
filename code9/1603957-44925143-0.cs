    SqlCommand cmd = new SqlCommand("update studetail set name= @name, gender = @gender, clas = @clas, section = @section where studentno = @studentno");
    cmd.Parameters.Add(new SqlParameter("name", textBox2.Text));  
    cmd.Parameters.Add(new SqlParameter("gender", gen));  
    cmd.Parameters.Add(new SqlParameter("clas", clas));  
    cmd.Parameters.Add(new SqlParameter("section", section));  
    cmd.Parameters.Add(new SqlParameter("studentno", textBox1.Text));  
