    public static void Main(string[] args) {
        new Program().Start();
    }
    public void Start() {
        GetNumber();
        GetNumber();
        GetNumber();
        Console.WriteLine("Wait...");
        Console.ReadKey();
    }
    public static async Task<int> GetNumber() {
        await Task.Delay(TimeSpan.FromSeconds(1));
        Console.WriteLine("Hello");
        return 0;
    }
