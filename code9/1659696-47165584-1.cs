    public List<TransactionIssues> GetAllTransactions()
            {
                using(var connection = new SqlConnection(connectionString))
                {
                    using(var command = new SqlCommand("issue_sp_getallunpostedissues", connection))
                    {
                        List<TransactionIssues> transIssues = new List<TransactionIssues>();
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader rdrObj;
                            connection.Open();
                            rdrObj = command.ExecuteReader();
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
                            rdrObj.Close();
                        
                        return transIssues;
                    }
                }
            }
