    public static async Task<Output> Calculation(int seed)
    {
        return new Output { Seed = seed, Result = 0 };
    }
    public class Output
    {
        public int Seed { get; set; }
        public int Result { get; set; }
    }
