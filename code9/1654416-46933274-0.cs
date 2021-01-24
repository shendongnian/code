    using System.Data.SqlClient;
    using System.Data;
    
    namespace WindowsFormsApplication3
    {
        public class Operations
        {
            string ConnectionString = "Data Source=KARENS-PC;" + 
                    "Initial Catalog=ForumExamples;Integrated Security=True";
    
            public DataTable Read()
            {
                DataTable dt = new DataTable();
    
                // add column so we can get one row/field on each button click
                dt.Columns.Add(new DataColumn() { ColumnName = "Used", DataType = typeof(bool) });
    
                using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = cn })
                    {
                        cmd.CommandText = "SELECT FullName FROM People";
    
                        cn.Open();
                        dt.Load(cmd.ExecuteReader());
                    }
                }
    
                // by default the column we added, the value is null so set it to false
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i].SetField<bool>("Used", false);
                }
    
                return dt;
            }
        }
    }
