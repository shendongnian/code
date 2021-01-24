    Console.Write("Where is  the capital of the state of Florida? A.Orlando,B.Tallahassee, C. Miami, or D. Tampa");
            var first = "";
            bool answeredCorrect = false; //Track B answered.
            int attempts = 0; //Track 2 attempts.
            while (!answeredCorrect && attempts < 2)
            {
                first = Console.ReadLine();
                switch (first)
                {
                    case "B":
                        Console.WriteLine("You entered the correct answer!");
                        score = score + 50;
                        Console.WriteLine("Correct!\n" + " score:" + score + "\n");
                        answeredCorrect = true;
                        break; //break and skip while because "answeredCorrect" is now true. 
                    case "A":
                        Console.WriteLine("You entered the wrong answer.");
                        attempts++; //Inkrement attempts. (One more try. Or skip if attemps is 2)
                        break;
                    //case C,D...
                    default:
                        Console.WriteLine("You did not enter a correct answer.");
                        attempts++; //Inkrement attempts. (One more try. Or skip if attemps is 2)
                        break;
                }
            }
         
            if(first != "B")
            {
                Console.WriteLine("Wrong!\n" + " score:" + score + "\n");
            }
