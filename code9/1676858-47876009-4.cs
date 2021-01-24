    public void PrintIds()
    {
        ExtendedTransfer extendedTransfer = _database.GetExtendedTransfer(...);
        PrintSubTransferIds(extendedTransfer);
    }
    
    private PrintSubTransferIds(Transfer transfer)
    {
        foreach(var subTransfer in transfer.SubTransfers)
        {
            Console.WriteLine(subTransfer.Id);
        }
    }
