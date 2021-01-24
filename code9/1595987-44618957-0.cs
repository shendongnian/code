        public static void Main(string[] args)
    {
        double v = 0.1;
        string name;
        /*string status;*/
        Console.WriteLine(v);
        Console.WriteLine("Hei buddy! What is your name?");
        name = Console.ReadLine();
        Console.WriteLine("Nice to meet you {0}. My name is PAI!", name);
        Console.WriteLine("How old are you {0}?", name);
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Wow. So you are {0}-years-old. That's a huge number, as I am only x day old.", age);
