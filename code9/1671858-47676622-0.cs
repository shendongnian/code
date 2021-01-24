     using (SqlConnection cn = new SqlConnection(connectionString))
                    {
    
                        cn.Open();
                        oSqlBulk = new SqlBulkCopy(connectionString,SqlBulkCopyOptions.FireTriggers);
                        
