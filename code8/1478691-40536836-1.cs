            string question1 = "The more you take, The more you leave behind. What am I?";
            Console.WriteLine(question1);
            while (Console.ReadLine() != "Footsteps")
            {
                Console.WriteLine("Sorry that is not correct!");
                Console.WriteLine(question1);
            }
            Console.WriteLine("That is correct! that is 5 points!");
            points = easyPoints;
            Console.WriteLine("You have " + points + " points");
            string question2 = "Mr.Smith has 4 daughters. Each of his daugthers has a brother. How many children does Mr.Smith has?";
            Console.WriteLine(question2);
            while(Console.ReadLine() != "5 children")
            {
                Console.WriteLine("Sorry that is not correct!");
                Console.WriteLine(question2);
            }
            points = easyPoints + 5;
            Console.WriteLine("You have " + points + " points");
