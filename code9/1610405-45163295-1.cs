    //Service proxies are typically thread safe
    var web = new WebService( ... );
    var readerBlock = new TransformManyBlock<MyFilterDTO,Entity>(async filter =>
    {
            using( IDatabaseService db = new DatabaseService( ... ) )
            {
                return await db.GetRows(filter.A,filter.B);
            }
    });
    var serviceOptions = new ExecutionDataflowBlockOptions
                         {
                            MaxDegreeOfParallelism = 10, 
                            BoundedCapacity=30
                         };
    var serviceBlock = new TransformBlock<Entity,(int id,RelatedInfo info)>(async row=>
    {
        var info = await web.GetRelatedInfo( row.Foo );
        await web.MakeAnotherServiceCall( row.Bar );
        return (row.Id,info);
    },serviceOptions);
    var updateBlock = new ActionBlock<(int id,RelatedInfo info)>(asyn result =>
    {
        using( IDatabaseService db = new DatabaseService( ... ) )
        {
            await db.UpdateEntity( result.id, result.info );
        }
    });
    var linkOptions=new DataflowLinkOptions{PropagateCompletion=true};
    readerBlock.LinkTo(serviceBlock,linkOptions);
    serviceBlock.LinkTo(updateBlock,linkOptions);
    //Start sending queries
    readerBlock.Post(someFilterValue);
    ...
    //We are finished, close down the pipeline
    readerBlock.Complete();
    try
    {
        //Await until all blocks finish
        await updateBlock.Completion;
    }
    finally
    {
        web.Dispose();
    }
