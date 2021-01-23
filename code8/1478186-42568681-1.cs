    while (AllowRun)
        {
            try
            {
                while (pendingLogs.Count > 0)
                {
                    using (DbContext context = GetNewDbContext())
                    {
                        while (AllowRun && context.GetConnection().State == ConnectionState.Open)
                        {
                            TEntity entity = null;
                            try
                            {
                            
                                lock (pendingLogs)
                                {
                                    entity = null;
                                    if (pendingLogs.Count > 0)
                                    {
                                        entity = pendingLogs[0];
                                        pendingLogs.RemoveAt(0);
                                    }
                                }
                                if (entity != null)
                                {
                                    context.Entities.Add(entity);
                                    context.SaveChanges();
                                }
                            }                        
                            catch (Exception e)
                            {
                                // (1)
                                // Log exception and continue execution
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
               // Log context initialization failure and continue execution
            }
        }
