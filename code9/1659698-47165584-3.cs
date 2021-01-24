    public List<TransactionIssues> GetAllTransactions()
            {
                using(var connection = new SqlConnection(connectionString))
                {
                    using(var command = new SqlCommand())
                    {
                        List<TransactionIssues> transIssues = new List<TransactionIssues>();
                        command.CommandText = "issue_sp_getallunpostedissues";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = connection;
                        
                            connection.Open();
                            using(SqlDataReader rdrObj = command.ExecuteReader())
                            {
                                while (rdrObj.Read())
                                {
                                    TransactionIssues issues = new TransactionIssues();
                                    issues.requisitionNumber = rdrObj.GetString(0);
                                    issues.transactionDate = rdrObj.GetDateTime(1);
                                    //issues.expense_acccount.account_desc = rdrObj.GetString(2);
                                    //issues.expense_acccount.index = rdrObj.GetInt16(3);
                                    issues.inventory_acccount.index = rdrObj.GetInt32(2);
                                    issues.inventory_acccount.account_desc = rdrObj.GetString(3);
                                    issues.docNumber = rdrObj.GetString(4);
                                    issues.docType = rdrObj.GetString(5);
                                    issues.items = getTransItemByRquisition(rdrObj.GetString(4));
                                    transIssues.Add(issues);
                                }
                            }
                            rdrObj.Close();
                        
                        return transIssues;
                    }
                }
            }
