    private void btnAdd_Click(object sender, EventArgs e)
    {
       try
       {
          using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(@"connecting string"))
          {
             con.Open();
             using (System.Data.SqlClient.SqlCommand cmd = con.CreateCommand())
             {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into Manipulate (ICNO,Name,Disease,Contact,History,Address,Gender) " + 
                                  "values(@ICNO,@Name,@Disease,@Contact,@History,@Address,@Gender)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ICNO", txtICNO.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Disease", txtDisease.Text);
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@History", txtHistory.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
    
                if (rdbMale.Checked)
                   cmd.Parameters.AddWithValue("@gender", "Male");
                else
                   cmd.Parameters.AddWithValue("@gender", "Female");
                cmd.ExecuteNonQuery();
             }
          }
    
       }
       catch (Exception ex)
       {
          MessageBox.Show(ex.Message);
          return;
       }
    
          displayData();
          MessageBox.Show("record add successfully");
       
    }
