            populate();
        }
    private void populate ()
    {
                using (SqlConnection con= new SqlConnection(connectionstring))
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlCommand cmd= new SqlCommand("Select ...", con);
                    cmd.CommandTimeout = 0;
                    SqlDataAdapter _dadapt= new SqlDataAdapter();
                    _dadapt.Fill(dt); 
                    con.Close();
                  Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                      dataGrid1.itemsSource = dt.DefaultView;
                    }));
                    
                }
    }
