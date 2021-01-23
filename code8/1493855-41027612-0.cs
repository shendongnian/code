            DB.Transactions.Add(new Transaction
            {
                CheckAccountId = transfer.CheckAccountId,
                Amount = -transfer.Amount,
                TransactionDate = DateTime.Now
            });
            DB.Transactions.Add(new Transaction
            {
                 CheckAccountId = checkingExistedAccount.Id,
                 Amount = transfer.Amount,
                 TransactionDate = DateTime.Now
            });
