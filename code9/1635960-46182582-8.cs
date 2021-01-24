    public class MyImplementation : ICalcLoaderTask<CopyNMStoreResult>
    {
        public async Task<CopyNMStoreResult> Execute(BaseTaskParameters taskParams,
                                                     CancellationToken cancellationToken)
        {
            ...
            var result = new CopyNMStoreResult
            {
                NMStoreResultsFilePath = GlobalNMStoreResultsFilePath
            };
            return result;
        }
    }
