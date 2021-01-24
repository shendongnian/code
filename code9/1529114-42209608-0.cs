    private void btn_Click(object sender, EventArgs e)
    {
      try
      {
       //create  object  of Connection Class..................
       SqlConnection con = new SqlConnection();
       // Set Connection String property of Connection object..................
      con.ConnectionString = "Data Source=KUSH-PC;Initial Catalog=test;Integrated           Security=True";
     // Open Connection..................
      con.Open();
     //Create object of Command Class................
     SqlCommand cmd = new SqlCommand();
    //set Connection Property  of  Command object.............
    cmd.Connection = con;
    //Set Command type of command object
    //1.StoredProcedure
    //2.TableDirect
    //3.Text   (By Default)
    cmd.CommandType = CommandType.Text;
    //Set Command text Property of command object.........
    cmd.CommandText = "Insert into Registration (Username, password) values ('@user','@pass')";
    //Assign values as `parameter`. It avoids `SQL Injection`
    cmd.Parameters.AddWithValue("user", TextBox1.text);
    cmd.Parameters.AddWithValue("pass", TextBox2.text);
           //Execute command by calling following method................
      1.ExecuteNonQuery()
           //This is used for insert,delete,update command...........
      2.ExecuteScalar()
           //This returns a single value .........(used only for select command)
      3.ExecuteReader()
          //Return one or more than one record.
      cmd.ExecuteNonQuery();
      con.Close();
      MessageBox.Show("Data Saved");          
      }
         catch (Exception ex)
         {
                MessageBox.Show(ex.Message);
                con.Close();
         }
           
        }
           
