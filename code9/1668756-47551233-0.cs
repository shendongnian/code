    public void Test(){
        Task.Factory.StartNew(() => Parallel.ForEach(Test1.myList, new ParallelOptions { MaxDegreeOfParallelism = 250 }, foo =>
        {
            // do stuff
        }));
