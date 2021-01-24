     DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(@"D:\Test.xml");               
                DataTable dtstatement = ds.Tables["Statement"];
                foreach (DataRow dr in dtstatement.Rows)
                {
                    Statement statement = new Statement();
                    statement.IdClient = Convert.ToInt32(dr["IdClient"].ToString());
                    statement.StatementNo = Convert.ToInt32(dr["StatementNo"].ToString());
                    DataRow[] selectedCards = ds.Tables["card"].Select(string.Format("StatementNo = {0}", statement.StatementNo));
                    if (selectedCards.Length > 0)
                    {
                        foreach (var item in selectedCards)
                        {
                            Card card = new Card();
                            card.IdClient = statement.IdClient;
                            card.CardNo = item["cardNo"].ToString();
                        }
                    }
                    DataRow[] selectedAccounts = ds.Tables["Account"].Select("StatementNo = " + statement.StatementNo);
                    if (selectedAccounts.Length > 0)
                    {
                        foreach (var item in selectedAccounts)
                        {
                            Account account = new Account();
                            account.IdClient = statement.IdClient;
                            account.AccountNo = item["AccountNo"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
