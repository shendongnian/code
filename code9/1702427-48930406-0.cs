            static void Run()
            { 
                string[] files = Directory.GetFiles("C:\\TEST\\", "*.*", SearchOption.AllDirectories);
                using (SqlConnection con = new SqlConnection("server=localhost;database=testdb;integrated security=true"))
                {
                    con.Open();
                    string insertSQLString = "INSERT INTO dbo.Test(content, path) VALUES(@File, @path)";
                    SqlCommand cmd = new SqlCommand(insertSQLString, con);
                    var pFile = cmd.Parameters.Add("@File", SqlDbType.VarBinary, -1);
                    var pPath = cmd.Parameters.Add("@path", SqlDbType.Text);
    
                    var tran = con.BeginTransaction();
                    var fn = 0;
                    foreach (string docPath in files)
                    {
                        fn += 1;
                        using (var stream = new FileStream(docPath, FileMode.Open, FileAccess.Read))
                        {
                            pFile.Value = stream;
                            pPath.Value = docPath;
                            cmd.Transaction = tran;
                            cmd.ExecuteNonQuery();
                            if (fn%10==0)
                            {
                                tran.Commit();
                                tran = con.BeginTransaction();
                                Console.Write("|");
                            }
                            Console.Write(".");
                        }
                    }
                    tran.Commit();
                }
            }
