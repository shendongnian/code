    static IEnumerable<string> GetDeferredConsoleReadLine()
    {
        yield return Console.ReadLine();
    }
    
    var query = from line in GetDeferredConsoleReadLine()
                from c in line
                group c by char.IsDigit(c) into gr
                select new { IsDigit = gr.Key, Count = gr.Count() };
