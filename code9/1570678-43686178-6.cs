    while (true)
    {
        using (var session = sessFactory.OpenSession())
        {
            try
            {
                using (var t = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    var coverage = session.QueryOver<Coverage>()
                        .Where(g => g.Description == description)
                        .Take(1).SingleOrDefault();
                    if (coverage == null)
                    {
                        coverage = new Coverage { Description = description };
                        session.Save(coverage);
                    }
                    t.Commit();
                    // Breaks the loop by the way.
                    return coverage;
                }
            }
            catch (GenericADOException ex)
            {
                // SQL-Server specific code for identifying deadlocks
                var sqlEx = ex.InnerException as SqlException;
                if (sqlEx == null || sqlEx.Number != 1205)
                    throw;
                // Deadlock, just try again by letting the loop go on (eventually
                // log it).
            }
        }
    }
