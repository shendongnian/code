     string retrivenp = "select emp_email from E_details where emp_ID = ? AND emp_name = ? AND emp_address = ? AND Date_joining = ?";
       
                   using (OdbcCommand comm1 = new OdbcCommand(retrivenp,con))
                    {
                      comm1.Parameters.Add("@p1", OleDbType.Int).Value =  c_c;
                      comm1.Parameters.Add("@p2", OleDbType.Text).Value =  s_s;
                      comm1.Parameters.Add("@p3", OleDbType.Text).Value =  n_n;
                      comm1.Parameters.Add("@p4", OleDbType.Date).Value =   Calendar1.SelectedDate;
       
                        using (OdbcDataReader read = comm1.ExecuteReader())
                        {                          
                            while(read.Read())
                            {
                                url_path = read.GetString(0);
                                Label1.Text = url_path.ToString();
                            }  
                             read.Close();
                         
                        }
                    }
      
