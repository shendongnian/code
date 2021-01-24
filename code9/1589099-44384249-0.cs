       try
                    {
                        connection.Open();
                        SQLiteCommand command = new SQLiteCommand(connection);
                        command.CommandText = "INSERT INTO SIP_JSON (sip_code, json) VALUES (?,?)";
                        command.Parameters.Add(new SQLiteParameter("sip_code",nextSipCode));
                        command.Parameters.Add(new SQLiteParameter("json", json));
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw new Exception(Exceptions.GATEWAYDB_INSESRTSIPJSON_EXCEPTION, e);
                    }
                    finally
                    {
                        connection.Close();
                    }
