    var strategy = _context.Database.CreateExecutionStrategy();
    await strategy.ExecuteAsync(async () =>
      {
        using (var dbContextTransaction = _context.Database.BeginTransaction())
        {
            // Your code here                    
            dbContextTransaction.Commit();
        }
        catch (Exception ex)
        {
            dbContextTransaction.Rollback();
            throw;
        }
      }
    });
