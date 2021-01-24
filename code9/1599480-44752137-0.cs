    class Example
    {
        private readonly BlockingCollection<Guid> _guidPool;
        private readonly TransformBlock<Foo, Bar> _transform;     
        public Example(int concurrentLimit)
        {
            _guidPool = new BlockingCollection<Guid>(new ConcurrentBag<Guid>(), concurrentLimit)
            for(int i = 0: i < concurrentLimit; i++)
            {
                _guidPool.Add(Guid.NewGuid());
            }
            _transform = new TransformBlock<Foo, Bar>(() => SomeAction, 
                                                      new ExecutionDataflowBlockOptions
                                                      {
                                                         MaxDegreeOfParallelism = concurrentLimit
                                                         //...
                                                      });
            //...
        }
        
        private async Task<Bar> SomeAction(Foo foo)
        {
            var id= _guidPool.Take();
            try
            {
                 //...
            }
            finally
            {
                _guidPool.Add(id);
            }
        }
    }
