    namespace Oppgave3Lesson1
    {
        class Program
        {
            static void Main(string[] args)
            {
                while(true)
                {
                    double sum = 0;
                    double num1;
                    Console.Write("First number: (or Exit)");
                    string firstNumStr = Console.ReadLine();
                    if(firstNumStr == "Exit") break;
                    num1 = Convert.ToInt32(firstNumStr);
                    double num2;
                    Console.Write("Second number: ");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Addisjon eller Subtraksjon?");
                    string regneoperasjon = Console.ReadLine();
                    if(regneoperasjon == "Subtraksjon")
                    {
                        Console.Write("Svaret til denne regneoperasjonen er: " + (sum = num1 - num2));
                    }
                    else if (regneoperasjon == "Addisjon")
                    {
                        Console.Write("Svaret til denne regneoperasjonen er: " + (sum = num1 + num2));
                    }
                }
     
