    static void Main(string[] args)
    {
        double x = Math.PI;
        for(int i = 0; i < 20; i++)
        {
            Debug.WriteLine(Nice(x, "g4"));
            x*=50;
        }
    }
