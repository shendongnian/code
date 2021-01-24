     public List<Email> GetEmails(List<int> listCustomerId)
        {
            var emailList = new List<Email>();
            var sql = "SELECT * FROM EmailsAddress WHERE Id IN (" + string.Join(",", listCustomerId) + ")";
            using ( var ObjectToAccessDatabaseAndStoreResultsIntoDataTable = new ObjectToObtainDbResultsIntoDataTable(_connection, sql))
            {
                foreach (DataRow row in  ObjectToAccessDatabaseAndStoreResultsIntoDataTable.Datatable)
                {
                    var email = new Email
                    {
                        MailAddress = Convert.ToString(row["MailAddress"]);
                        MailOwner = Convert.ToString(row["MailOwner"]);
                        MailSended = Convert.ToInt32(row["MailSended"]);
                        MailReceived = Convert.ToInt32(row["MailReceived"]);
                    }
                    emailList.Add(email);
                }
                return emailList;
            }
        }
