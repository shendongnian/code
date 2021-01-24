    private readonly ReaderWriterLockSlim _rwls = new ReaderWriterLockSlim();
    async void button1_Click(object sender, EventArgs e)
    {
        _rwls.EnterWriteLock();
        await ...;
        _rwls.ExitWriteLock();
    }
