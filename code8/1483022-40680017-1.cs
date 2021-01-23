    public EventHubConfiguration(
            EventProcessorOptions options, 
            PartitionManagerOptions partitionOptions = null)
    {
        if (options == null)
        {
            options = EventProcessorOptions.DefaultOptions;
            options.MaxBatchSize = 1000;
         }
         _partitionOptions = partitionOptions;
         _options = options;
    }
