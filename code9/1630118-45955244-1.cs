        interface ICommon
        {
            byte[] TransactionSequence { get; set; }
        }
        public void GroupChanges<TResult>(List<TResult> changes) 
             where TResult: ICommon 
        {
            List<IGrouping<byte[], TResult>> changeSet = changes
                    .GroupBy(change => change.TransactionSequence , new ArrayComparer<byte>())
                    .ToList();
        }
