    private DataTable GetEmployeesList()
        {
            DataTable dtEmployees = new DataTable();
            using (SqlConnection con = new SqlConnection("Data Source=yourconnectin;Initial Catalog=dbtest;Integrated Security=True"))
            {
                cn.Open();
                string createTable = "IF OBJECT_ID('List') IS  NULL Begin " +
                   "CREATE TABLE [dbo].[List]("+
                          " [IDNumbers] INT IDENTITY(1, 1) NOT NULL,"+
                            "[Numbers] DECIMAL(18, 8) NULL," +
                            "  CONSTRAINT[PK_List] PRIMARY KEY CLUSTERED([IDNumbers] ASC))" +
                     "END";
                using (SqlCommand cmddd = new SqlCommand(createTable, cn))
                {
                    cmddd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM List", cn))// List1 for Testing...
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtEmployees.Load(reader);
                }
            }
            return dtEmployees;
        }
