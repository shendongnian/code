        var accounts = new List<Account>();
        var context = new YourDbContext();
        context.Configuration.AutoDetectChangesEnabled = false;
                foreach (var account in apiData)
                {
                    accounts.Add(account);
                    if (accounts.Count % 1000 == 0) 
                    // Play with this number to see what works best
                    {
                        context.Set<Account>().AddRange(accounts);
                        accounts = new List<Account>();
                        context.ChangeTracker.DetectChanges();
                        context.SaveChanges();
                        context?.Dispose();
                        context = new YourDbContext();
                    }
                }
                context.Set<Account>().AddRange(accounts);
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
                context?.Dispose();
