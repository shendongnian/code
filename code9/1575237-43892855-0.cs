            var emailHistory = emailHistories.FirstOrDefault(key => key.EmailVersionKey == emailID);
            if (emailHistory != null)
            {
                emailHistory.EmailVersionData.Add(newEmailVersionData);
            }
            else
            {
                List<EmailVersionData> list = new List<EmailVersionData>();
                EmailsVersionHistory item = new EmailsVersionHistory() { EmailVersionKey = emailID, EmailVersionData = list };
                list.Add(newEmailVersionData);
                emailHistories.Add(item);
            }
