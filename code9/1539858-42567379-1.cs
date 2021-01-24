    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\t\t\t\t\t\t\tCalcualtor");
            Console.WriteLine("\t\t\t\t\t\t\t----------");
            double a = GetNumber("put Number Plz");
            double b = GetNumber("put other Number Plz");
            string uservalue = GetOperator("Choose :*,+,-,/");
            if (uservalue == "*")
            {
                Console.Write("Resultat= " + a * b);
            }
            else if (uservalue == "+")
            {
                Console.Write("Resultat= " + (a + b));
            }
            else if (uservalue == "-")
            {
                Console.Write("Resultat= " + (a - b));
            }
            else if (uservalue == "/")
            {
                Console.Write("Resultat= " + (a / b));
            }
            Console.ReadLine();
            Console.Clear();
        }
