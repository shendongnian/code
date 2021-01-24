    int Sum=0;
    string s="0";
    while (!s.Equals("=")) {
        Sum += Convert.ToInt16(s);
        Console.Write("Type a number (Enter = to get the sum): ");
        s = Console.ReadLine();
    }
    Console.WriteLine("The sum is " + Sum.ToString());
