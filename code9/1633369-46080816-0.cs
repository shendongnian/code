    public static void CurrentQuestion(string correctAnswer)
    {
        do
        {
            Console.WriteLine("Please enter answer: ");
            string userAnswer = Console.ReadLine();
            if ((userAnswer != "A") && (userAnswer != "B") && (userAnswer != "C") && (userAnswer != "D"))
            {
                Console.WriteLine("\nError - Not a Valid Input");
                continue;
            }
            else
            {
                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("\nThat is correct!");
                    break;
                }
                else if (userAnswer != correctAnswer)
                {
                    Console.WriteLine("\nSorry, that is incorrect");
                    break;
                }
            }
        } while (true);
    }
