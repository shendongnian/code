    public List<float> Payments(int tripCount)
    {
        List<float> a = new List<float>();
        float input;
        for (int i = 0; i < tripCount; i++)
        {
            Console.Write("Enter payment {0}: ", (1 + i));
            input = float.Parse(Console.ReadLine());
            Console.WriteLine("Payment added");
            a.Add(input);
        }
        return a;
    }
