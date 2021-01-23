            DataSet ds = new DataSet();
            using(SqlConnection conn = new SqlConnection("YourConnectionString"))
            {
                conn.Open();
                string str = "if object_id('tempdb..#mytest') is not null drop table #mytest; create table #mytest (id int)";
                // create temp table
                using(SqlCommand cmdc = new SqlCommand(str, conn))
                {
                    cmdc.ExecuteNonQuery(); 
                }
                // insert row
                using (SqlCommand cmdi = new SqlCommand("insert #mytest (id) values (1)", conn))
                {
                    cmdi.ExecuteNonQuery();
                }
                // use it
                using (SqlCommand cmds = new SqlCommand("dbo.mytestproc", conn))
                {
                    cmds.CommandType = CommandType.StoredProcedure;
                    cmds.Parameters.Add("@id", SqlDbType.Int).Value = 1;
                    cmds.Connection = conn;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmds))
                    {
                        da.Fill(ds);
                    }
                } 
            }
            MessageBox.Show("done, num rows " + ds.Tables[0].Rows.Count);
