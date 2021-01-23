            string name;
            Console.WriteLine("\nYou're awake? It's about time. Not old enough, eh? That sucks. \n\nListen, I really need your help. Would you be interested? Y / N");
            char yes = Console.ReadKey();
            if (yes == 'y' || yes == 'Y')
            {
                Console.Write("\nYou will?! Wow, That's fantastic. Right then, where shall I start? \nI know! How about telling me your name? ");
                name = Console.ReadLine();
                Console.WriteLine("\nAhh yes, now you mention it, I certainly remember you, {0}!", name);
                Console.ReadKey(); // I put this here so the program wouldn't exit
            }
            else
            {
                Console.WriteLine("\nYou don't want to help me? Oh, that's unfortunate... ");
            }
