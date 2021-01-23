    private static readonly int MAX_ITEMS = 10;
    DataStore centralDataStructure = new DataStore();
    private ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();
    /*Code that calls processRecord on many different lines on many
    different threads at once*/
    private void processRecord(string line)
    {
        Record rec = processLine(line); // Expensive
        //Allows unlimited concurrent readers and a single upgradeable reader.
        readerWriterLock.EnterReadLock()
        try
        {
            centralDataStructure.insertRecord(rec);
        }
        finally
        {
            readerWriterLock.ExitReadLock()
        }
        //Allows other readers, blocks writers and other upgradeable readers.
        readerWriterLock.EnterUpgradeableReadLock()
        try
        {
            if (centralDataStructure.Size > MAX_ITEMS) // Ok if we go slightly over MAX_ITEMS
            {
                //Blocks new readers and other writers. Waits for current readers to finsh before unblocking.
                readerWriterLock.EnterWriteLock();
                try
                {
                    centralDataStructure.flushToExternalDataStore();
                }
                finally
                {
                    //Allow readers again.
                    readerWriterLock.ExitWriteLock();
                }
            }
        }
        finally
        {
             //Allow writers and upgradeable readers again.
             readerWriterLock.ExitUpgradeableReadLock()
        }
    }
