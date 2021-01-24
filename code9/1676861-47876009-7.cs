    public void PrintIds()
    {
        ExtendedTransfer extendedTransfer = _database.GetExtendedTransfer(...);
        PrintSubTransferIds(extendedTransfer.SubTransfers);
    }
    
    private PrintSubTransferIds(List<SubTransfer> subTransfers)
    {
        foreach(var subTransfer in subTransfers)
        {
            Console.WriteLine(subTransfer.Id);
        }
    }
