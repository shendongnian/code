     static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                int rowcounts = 0;
    
                SqlConnection connCount = locald.DB.GetSqlConnection();
                System.Data.SqlClient.SqlCommand com = new 
                System.Data.SqlClient.SqlCommand();
                com.Connection = connCount;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = @"countval";
                rowcounts = Convert.ToInt32(com.ExecuteScalar());
    
                
                if (rowcounts == 0){
                    Application.Run(new Form2()); //if database has no records
                }
                else
                {
                    Application.Run(new Form1());
                }
            }
