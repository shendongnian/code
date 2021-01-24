        using (SqlConnection con = new SqlConnection(constr))
             {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("select * from PatientInfo", con))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            datagridpatient.DataSource = dt;
                            datagridpatient.Columns["ID"].Visible = false;
                            con.Close();
                        }
                    }
                }
             }
    
