    protected void b_Click(object sender, EventArgs e)
            {
                string Source = ConfigurationManager.ConnectionStrings["NSGC"].ConnectionString;
                string Destination = ConfigurationManager.ConnectionStrings["NSGD"].ConnectionString;
                using (SqlConnection sourceCon = new SqlConnection(Source))
                {
                    SqlCommand cmd = new SqlCommand("select * from source_table", sourceCon);
                    sourceCon.Close();
                    sourceCon.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        using (SqlConnection Dcon = new SqlConnection(Destination))
                        {
                            using(SqlBulkCopy bc=new SqlBulkCopy(Dcon))
                            {
                                bc.BatchSize = 200;
                                bc.NotifyAfter = 100;
                                bc.DestinationTableName = "target_table";
                                Dcon.Open();
                                bc.WriteToServer(rdr);
                            } 
                                
                        }
                    }
                    
                }
            }
