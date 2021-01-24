    var batchBlock = new BatchBlock<(int id,RelatedInfo info>(10);
    var updateBlock = new ActionBlock<(int id,RelatedInfo info)[]>(asyn results =>
    {
        using( IDatabaseService db = new DatabaseService( ... ) )
        {
            foreach(var result in results)
            {
                await db.UpdateEntity( result.id, result.info );
            }
        }
    });
    var linkOptions=new DataflowLinkOptions{PropagateCompletion=true};
    readerBlock.LinkTo(serviceBlock,linkOptions);
    serviceBlock.LinkTo(batchBlock,linkOptions);
    batchBlock.LinkTo(updateBlock,linkOptions);
