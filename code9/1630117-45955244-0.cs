    interface ICommon
    {
        byte[] TransactionSequence { get; set; }
    }
    public void GroupChanges<TResult>(List<TResult> changes) where TResult: ICommon {.. }
