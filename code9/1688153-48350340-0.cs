    class MainClass
    {
        public static void Main(string[] args)
        {
            //Variable Declarations
            string response,
                   name;
            string[] scores;
            int sumOfAllScores,
                scoreCount;
            bool validResponse;
            System.Text.RegularExpressions.Regex onlyDigits;
            //We need to assign response an initial value or else Visual Studio will complain
            //since it only receives its real value within a while loop (which as far as the parser is concerned
            //may or may not ever iterate.
            response = string.Empty;
            //Booleans are automatically assigned an intial value of 'false' but I like to intialize them anyway
            validResponse = false;
            //Initialize the score sum and score counter variables.
            sumOfAllScores = 0;
            scoreCount = 0;
            //This Regex pattern will allow us to inspect a string to ensure that it contains only digits.
            onlyDigits = new System.Text.RegularExpressions.Regex(@"^\d+$");
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("Hello, " + name);
            //This loop will iterate until the user provides valid input (comma-separated integers).
            while (!validResponse)
            {
                //When we enter the while loop, set validResponse to true.
                //If we encounter any invalid input from the user we will set this to false so that
                //the while loop will iterate again. 
                validResponse = true;
                Console.Write("What are your last three test scores (comma-separated list, please): ");
                response = Console.ReadLine();
                //Split response into an array of strings on the comma characters
                scores = response.Split(',');
                //Inspect each element of the string array scores and take action:
                foreach (string scoreEntry in scores)
                {
                    //If the current array member being inspected consists of any characters that are not integers,
                    //Complain to the user and break out of the foreach loop.  This will cause the while loop to iterate
                    //again since validResponse is still false.
                    if (!onlyDigits.IsMatch(scoreEntry))
                    {
                        //Complain
                        Console.WriteLine("Invalid response. Please enter a comma-separated list of test scores");
                        Console.WriteLine(Environment.NewLine);
                        //Re-initialize the score sum and score count variables since we're starting over
                        sumOfAllScores = 0;
                        scoreCount = 0;
                        //Set validResponse to false and break out of the foreach loop
                        validResponse = false;
                        break;
                    }
                    //Otherwise, we have valid input, so we'll update our integer values
                    else
                    {
                        //Iterate the number of scores that have been entered and validated
                        scoreCount++;
                        //Use the static Convert class to convert scoreEntry to an Integer
                        //and add it to the score sum
                        sumOfAllScores += Convert.ToInt32(scoreEntry);
                    }
                }
            }
            //Report the results to the user:
            Console.WriteLine("Your test scores are: " + response);
            Console.WriteLine("Your average score is " + sumOfAllScores / scoreCount);
        }
    }
