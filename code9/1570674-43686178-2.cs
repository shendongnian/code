    while(true)
    {
        using(var session = sessFactory.OpenSession())
        {
            try
            {
                using(var t = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    Coverage coverage = session.QueryOver<Coverage>()
                        .Where(g => g.Description == description)
                        .Take(1).SingleOrDefault();
                    if (coverage == null)
                    {
                        coverage = new Coverage { Description = description };
                        session.Save(coverage);
                    }
                    t.Commit();
                    return coverage;
                }
            }
            catch (GenericADOException ex)
            {
                var sqlEx = ex.InnerException as SqlException;
                if (sqlEx == null)
                    throw;
                // SQL-Server code for deadlock
                if (sqlEx.Number != 1205)
                    throw;
                // Deadlock, just try again by letting the loop go on (eventually
                // log it).
            }
        }
    }
