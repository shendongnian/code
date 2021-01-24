    var newTransactionScope = TransactionUtils.CreateTransactionScope();
            
               try
                {
                    using (newTransactionScope)
                    {
                        using (var dbContextTransaction = db_context.Database.BeginTransaction(/*System.Data.IsolationLevel.ReadCommitted*/))
                        {
                            try
                            {
                                db_context.Database.CommandTimeout = 3600;
                                db_context.Database.SqlQuery<UpdateData>("UpdateProc @Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @DateModified",
                                    new SqlParameter("Param1", test1),
                                    new SqlParameter("Param2", test2),
                                    new SqlParameter("Param3", test3),
                                    new SqlParameter("Param4", test4),
                                    new SqlParameter("Param6", test5),
                                    new SqlParameter("DateModified", DateTime.Now)).ToList();
                                dbContextTransaction.Commit();
                            }
                            catch (TransactionAbortedException ex)
                            {
                                dbContextTransaction.Rollback();
                                throw;
                            }
