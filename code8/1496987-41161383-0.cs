    private static SQLiteAsyncConnection _conn;
    private static readonly AsyncLock _mutex = new AsyncLock();
    private static async Task<SQLiteAsyncConnection> GetDb(Context context)
    {
        try
        {
            using (await _mutex.LockAsync())
            {
                if (_conn != null)
                {
                    return _conn;
                }
                _conn = new SQLiteAsyncConnection(GetDbPath(context), storeDateTimeAsTicks: false);
                return _conn;
            }
        }
        catch (Exception e)
        {
            throw;
        }
    }
