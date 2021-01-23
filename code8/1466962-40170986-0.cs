     using(getConnection.sqlCmd = new SqlCommand(sqlQuery,getConnection.sqlcon))
                {
                    using(var reader = getConnection.sqlCmd.ExecuteReader())
                    {
                        int x = 0;
                        try
                        {
                            while (reader.Read())
                            {
                                col1 = reader.GetValue(0).ToString();
    
                                if (col1.Equals("Y"))
                                {
                                    dgvAccident.Rows[x].Cells[4].Value = true;
                                    ++x;
                                }
                                else
                                    if (col1.Equals("N"))
                                    {
                                        dgvAccident.Rows[x].Cells[4].Value = false;
                                        ++x;
                                    }
                            }
                        }
