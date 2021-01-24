    			    string QueryGetData = "select Name as Name , Age as Age from tableone;";
                            SqlCommand cmd = m_SqlConnection.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = QueryGetData;
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                List<string> Data = new List<string>();
                                string strName = reader["Name"] != System.DBNull.Value ? reader["ServiceName"].ToString() : "";
				string strName = reader["Age"] != System.DBNull.Value ? reader["Age"].ToString() : "";
               //If Int Set Default as Zero
				int nIntValue = reader["IntColumnName"] != System.DBNull.Value ? Convert.ToInt32(reader["IntColumnName"].ToString()) : 0;
			    }
