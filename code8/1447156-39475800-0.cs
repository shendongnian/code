                var existingCount = 0l;
                var lastCount = -1l;
                while (existingCount < items.Count)
                {
                    using (var session = factory.OpenSession())
                    {
                        existingCount = session.CreateCriteria<BaseClass>()
                                               .SetProjection(Projections.RowCountInt64())
                                               .List<long>()
                                               .Sum();
                        session.Flush();
                    }
                    if (existingCount == items.Count)
                    {
                        break; // success
                    }
                    if (lastCount == existingCount)
                    {
                        throw new Exception("Error restoring backup, no change after retrying inserting new items.");
                    }
                    lastCount = existingCount;
                    try
                    {
                        using (var session = factory.OpenSession())
                        {
                            var existingItems = session.QueryOver<BaseClass>().List<BaseClass>().ToList();
                            SaveItemsToDb(existingItems, items, session); // checks if item already exists, if not, tries to save it. Also has some try-catch processing
                            session.Flush();
                        }
                    }
                    catch (Exception exception)
                    {
                        //Do nothing, just try again.
                    }
                }
