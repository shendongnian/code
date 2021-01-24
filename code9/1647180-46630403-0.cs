    private string Process(string line)
    {
        // Your logic for given line
    }
    private void Button_Click(object sender, EventArgs e)
    {
        var results = new ConcurrentBag<string>();
        Parallel.ForEach(txtSearchTerms.Lines,
                         line =>
                         {
                             var result = Process(line);
                             results.Add(result);
                         });
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }  
