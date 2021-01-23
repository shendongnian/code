    ((IObjectContextAdapter)db).ObjectContext.Connection.Open();
    using (System.Data.Common.DbTransaction transaction = ((IObjectContextAdapter)db).ObjectContext.Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
        {
            try
            {
                using (db)
                {
                    for(int i=0; i<length of record; i ++)
                    {
                        SwiftTable sw = new SwiftTable();
                        sw.acc_no = from file i get acc no;
                        sw.amount= ......................;
                        sw.bank=.........................;
                        db.Add.SwiftTable(sw);
                        db.SaveChanges();
                    }
    
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
        }
