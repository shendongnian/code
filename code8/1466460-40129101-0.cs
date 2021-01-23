        public void ScoreCalc()
        {
            string goon = " ";
            int counter = 1;
            int score = 0;
            var userInput = string.Empty;
            var inputNumber = 0;
            const string exitValue = "quit";
            while (goon == " ")
            {
                Console.WriteLine("Enter a score or type quit to exit.");
                userInput = Console.ReadLine();
                if (userInput.ToLower() == exitValue)
                {
                    break;
                }
                score += int.TryParse(userInput, out inputNumber) ? inputNumber : 0;
                Console.WriteLine(score + " " + counter);
                counter++;
            }
        }
