    public void ScoreCalc()
    {
        string goon = " ";
        int counter = 1;
        int score = 0;
        int userInput = 0;
        bool isInt = true;
        while (goon == " ")
        {
            Console.WriteLine("Enter a score");
            
            isInt = Int32.TryParse(Console.ReadLine(), out userInput);
    
            if(isInt)
            {
                score += userInput;
                Console.WriteLine(score + " " + counter);
                counter++;
            }
            else
            {
                goon = "exit";
            }
        }
    }
