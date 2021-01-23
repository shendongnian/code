        public static void Main(string[] args)
        {
            int points = 0;
            
            string question1 = "The more you take, The more you leave behind. What am I?";
            string answer1 = "Footsteps";
            points += Question(question1, answer1);
            Console.WriteLine("You have " + points + " points");
            string question2 = "Mr.Smith has 4 daughters. Each of his daugthers has a brother. How many children does Mr.Smith has?";
            string answer2 = "5 children";
            points+= Question(question2, answer2);
            Console.WriteLine("You have " + points + " points");
        }
        public static int Question(string question, string answer)
        {
            Console.WriteLine(question);
            while (Console.ReadLine() != answer)
            {
                Console.WriteLine("Sorry that is not correct!");
                Console.WriteLine(question);
            }
            return 5;
        }
