    public static void Main(string[] args)
    {
        int counter = 1;
        do
        {
            string stars = starGenerator(counter);
            Console.WriteLine(stars);
                    
            counter++;
        } while(counter <= 5);
    }
