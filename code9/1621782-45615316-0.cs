    private static async Task<int> GetAnswerToLife()
    {
        await Task.Delay(5000);
        int answer = 21 * 10;
        Console.WriteLine(answer);
        return answer;
    }
    private static void Main(string[] args)
    {
        var answering = GetAnswerToLife();
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(100);
        }
        // Calling .Result will ensure the answer has been calculated
        int a = answering.Result;
    }
