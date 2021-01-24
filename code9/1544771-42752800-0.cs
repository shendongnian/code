                using System.Data;
                using System.Data.SqlClient;
                
                SqlConnection conn = new SqlConnection("Data Source=IP; Initial Catalog=DataBaseName; User Id=sa; password=123;");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Profiles WHERE USERNAME=@USERNAME AND PASSWORD=@PASSWORD", conn);
                cmd.Parameters.AddWithValue("@USERNAME",textBox1.Text);
                cmd.Parameters.AddWithValue("@PASSWORD",textBox2.Text);
                if(cmd.ExecuteNonQuery()>0)
                {
                   //Login
                }
                else
                {
                   MessageBox.Show("You have entered a wrong user name or password!");
                }
                conn.Close();
