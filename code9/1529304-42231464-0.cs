    protected async Task ProcessRecords(DateTime loadedAt, string email)
    {
        try
        {
            using (var conn = new AppContext())
            {
                await conn.Database.ExecuteSqlCommandAsync("DedecatedProcesses @p0, @p1;", loadedAt, email)
                    .ConfigureAwait(false);
            }
        }
        catch (Exception e)
        {
            // Do something with e.Message
        }
    }
