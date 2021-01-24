    int question = 25;
    int answer;
    do
    {
       Console.Write("Guess the number: ");
       string strAnswer = Console.ReadLine();
       answer = Convert.ToInt32(strAnswer);
       if (answer < question)
       {
           Console.WriteLine("Too low, guess again. ");
       }
       else if (answer > question)
       {
           Console.WriteLine("Too high, guess again. ");
       }
    }
    while (answer != question);
