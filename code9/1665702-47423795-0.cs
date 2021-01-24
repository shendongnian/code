    using (var transaction = dbContext.Database.BeginTransaction(System.Data.IsolationLevel.Snapshot))
        try {
            // Read status, process payment here
        } catch () {
            transaction.Rollback()
        }
        }
    }
