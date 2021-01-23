    async Task SomeAsynMethod(IProgress<double> progress)
    {
        double percentCompletedSoFar = 0;
        while (!completed)
        {
            // your code here to do something
            
            if (progress != null)
            {
                prgoress.Report(percentCompletedSoFar);
            }
        }
    }
