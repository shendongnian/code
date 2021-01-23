    static void Main(string[] args)
    {
        Console.WriteLine(ReplaceMacro("{0} job for admin", new Job { Id = 1, Name = "Todo", Description = "Nothing" }));
        Console.ReadLine();
    }
    static string ReplaceMacro(string value, Job job)
    {
        return string.Format(value, job.Name);
    }
