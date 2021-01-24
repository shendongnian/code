    private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
    [HttpPost]
    public async SomeMethod()
    {
      if (cacheLock.TryEnterWriteLock(timeout));
      {
        try
        {
          // DoWork that should be very fast
        }
        finally
        {
          cacheLock.ExitWriteLock();
        }
      }
    }
