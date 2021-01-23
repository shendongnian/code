    private static async Task DisposeDbConnectionAsync()
    {
        using (await _mutex.LockAsync())
        {
            if (_conn == null)
            {
                return;
            }
            await Task.Factory.StartNew(() =>
            {
                _conn.GetConnection().Close();
                _conn.GetConnection().Dispose();
                _conn = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            });
        }
    }
