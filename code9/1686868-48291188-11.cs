    public IEnumerable<int> ThousandSquares()
    {
        for (int i = 1; i <= 1000; i++) {
            yield return i * i;
        }
    }
    public void PrintSquares()
    {
        foreach (int n in ThousandSquares()) {
            Console.WriteLine(n);
        }
    }
