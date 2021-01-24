    using (var ee = new EntitiesTest())
    using (var transaction = new TransactionScope())
    {
       ee.spMoneyUpdate(  ...)
       ee.spUpdateTotals();
       transaction.Complete();
    }
