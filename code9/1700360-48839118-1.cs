     var reader = sqlCmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if(userPassword == reader[0].ToString())
                            {
                                flag = true;
                            }
                        }
                    }
