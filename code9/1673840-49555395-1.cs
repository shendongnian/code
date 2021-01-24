                using (var dbi = new TimeTrackerUwpContext())
                {
                    var databaseCreator = (RelationalDatabaseCreator)dbi.Database.GetService<IDatabaseCreator>();
                    if (!databaseCreator.Exists())
                        await databaseCreator.EnsureCreatedAsync();
                    else
                        dbi.Database.ExecuteSqlCommand("DELETE FROM [Account];");
                    var acc = GetAccoutsToSync().Result;
                    if (acc.Count == 0)
                        return;
                    await dbi.Account.AddRangeAsync(acc);
                    await dbi.SaveChangesAsync();
                }
