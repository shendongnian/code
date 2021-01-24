     using System.Data.SqlClient;
     SqlConnection conn = new SqlConnection();
     conn.ConnectionString = 
     "Data Source=.\SQLExpress;" + 
     "User Instance=true;" + 
     "Integrated Security=true;" + 
     "AttachDbFilename=|DataDirectory|Database2.mdf;"
     conn.Open();
