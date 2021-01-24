            sqlConnection1.Open();
            Using cmd as new SqlCommand("stSelect", sqlConnection1);
              cmd.Parameters.AddWithValue("@stNo", textBox1.Text);
              cmd.ExecuteNonQuery();
              sqlDataAdapter1.SelectCommand = cmd;
              sqlDataAdapter1.Fill(dataSet41);
              sqlConnection1.Close();
  
            End Using
                    }
