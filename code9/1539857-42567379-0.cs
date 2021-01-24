    static double GetNumber(string prompt) {
        double answer;
        Console.WriteLine(prompt);
        while (true) {
            if (double.TryParse(Console.ReadLine(), out answer)) {
                return answer;
            }
           Console.WriteLine("Error: Try again");
        }
    }
    static string GetOperator(string prompt) {
        string answer;
        Console.WriteLine(prompt);
        while (true) {
            answer = Console.ReadLine();
            if ("*/+-".Contains(answer)) {
                return answer;
            }
           Console.WriteLine("Error: Try again");
        }
    }
