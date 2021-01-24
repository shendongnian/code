                DataTable dt = new DataTable();
                dt.Columns.Add("Value");
                dt.Columns.Add("Display");
                string query = @"SELECT ID AS ID, Description AS CODE FROM [Tender] ORDER BY ID";
                SqlDataReader sqlReader = new SqlCommand(query, DB.SQLConnection).ExecuteReader();
                while (sqlReader.Read())
                {
                    if (!string.IsNullOrEmpty(sqlReader["CODE"].ToString()))
                        dt.Rows.Add(sqlReader["ID"].ToString(), sqlReader["CODE"].ToString());
                }
                cbPayment1.DisplayMember = "display";
                cbPayment1.ValueMember = "value";
                cbPayment1.DataSource = dt;
