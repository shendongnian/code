    private static void RetryPolicy()
    {
        var retryPolicy = Policy.Handle<Exception>().Retry(2);
        List<int> list = new List<int>();
        list.AddRange(new int[] { 0, 1, 2, 3, 4 });
        foreach(var item in list)
        {
           var policyResult = retryPolicy.ExecuteAndCapture(() => Calculate(item));
           if (policyResult.Outcome != OutcomeType.Successful) 
           {
               // do something remedial. then the loop can continue.
           }
        }
    }
