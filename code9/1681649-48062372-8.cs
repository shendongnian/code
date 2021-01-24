    static void Main(string[] args)
    {
        // Type code here.
        double x = Math.PI/50e5;
        for(int i = 0; i < 20; i++)
        {
            // Format output to 12 wide column, right aligned
            Debug.WriteLine($"{ Eng(x, "g4"),12}");
            x*=50;
        }
    }
