    SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                     SqlCommand com = new SqlCommand();
                     SqlDataReader sqlReader;
                     com.CommandText = string.Format("Select id from {0}", tablename);
                     com.CommandType = CommandType.Text;
                     com.Connection = sqlCon;
                     sqlCon.Open();
                     sqlReader = com.ExecuteReader();
                     var dt = new DataTable();
                     dt.Load(sqlReader); //Query output is in dt now
