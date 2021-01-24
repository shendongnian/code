     var result = Context.User
                    .Where(u => u.UserId == myguid)
                    .Select(t => new
                    {
                        UserId = t.UserId,
                        Transactions = t.TransactionHistory.Where(x => x.CreatedDateTime >= StartDateFilter && x.CreatedDateTime <= EndDateFilter)
                    })
                    .ToList();
