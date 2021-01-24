        public void SaveChanges()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < transactions.Count; i++)
                        {
                            KeyValuePair<string, object> command = transactions[i];
                            // 1. Execute the command, but use an output parameter to capture the generated id
                            var cmd = sqlConnection.CreateCommand();
                            cmd.Transaction = sqlTransaction;
                            cmd.CommandText = command.Key;
                            SqlParameter p = new SqlParameter()
                            {
                                ParameterName = "@OutId",
                                Size = 4,
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(p);
                            cmd.ExecuteNonQuery();
                            // Check if the value was set, non insert operations wil not set this parameter
                            // Could optimise by not preparing for the parameter at all if this is not an 
                            // insert operation.
                            if (p.Value != DBNull.Value)
                            {
                                int idOut = (int)p.Value;
                                // 2. Stuff the value of Id back into the Id field.
                                string foreignKeyName = null;
                                SetIdValue(command.Value, idOut, out foreignKeyName);
                                // 3. Update foreign keys, but only in commands that we haven't execcuted yet
                                UpdateForeignKeys(foreignKeyName, idOut, transactions.Skip(i + 1));
                            }
                        }
                        sqlTransaction.Commit();
                    }
                    catch
                    {
                        sqlTransaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        sqlConnection.Close();
                        transactions.Clear();
                    }
                }
                sqlConnection.Close();
            }
            transactions.Clear();
        }
        /// <summary>
        /// Update the Id field of the specified object with the provided value
        /// </summary>
        /// <param name="item">Object that we want to set the Id for</param>
        /// <param name="idValue">Value of the Id that we want to push into the item</param>
        /// <param name="foreignKeyName">Name of the expected foreign key fields</param>
        private void SetIdValue(object item, int idValue, out string foreignKeyName)
        {
            // NOTE: There are better ways of doing this, including using interfaces to define the key field expectations.
            // This logic is consistant with existing code so that you are familiar with the concepts
            Type itemType = item.GetType();
            foreignKeyName = null;
            System.Reflection.PropertyInfo[] properties = itemType.GetProperties();
            for (int I = 0; I < properties.Count(); I++)
            {
                if (properties[I].Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase) || properties[I].Name.Equals("AutoId", StringComparison.CurrentCultureIgnoreCase))
                {
                    properties[I].SetValue(item, idValue);
                    foreignKeyName = $"{item.GetType().Name}_{properties[I].Name}";
                    break;
                }
            }
        }
 
