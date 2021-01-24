     [TestMethod]
            public void TestMethod1()
            {
                DataSet ds = new DataSet();
                var procName = "sp_server_info";
                string constr = ConfigurationManager.ConnectionStrings["UAT"].ConnectionString;
                var tblName = "result";
                var tbls = new[] { ds.Tables.Add(tblName) };
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(procName))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
    
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(0, 10, tbls);
                        }
                    }
                }
                Assert.AreEqual(tbls[0].Rows.Count, 10);
    
            }
