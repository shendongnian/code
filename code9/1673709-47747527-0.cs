            string Input = "";
            var Words = new List<string> { "elephant", "lion" };
            var Clues = new List<string> { "Has trunk?", "Is gray?", "Is yellow?", "Has mane?" };
            Console.WriteLine("Do you want to add you own animal? y/n ? \n");
            Input = Console.ReadLine();
            if (Input == "Y" || Input == "y")
            {
                Console.WriteLine("Enter an animal name: \n");
                //Array.Resize(ref Words, Words.Length + 1);
                Input = Console.ReadLine();
                Words.Add(Input);
                Console.WriteLine("Enter 2 clues \n");
                for (int i = 1; i <= 2; i++)
                {
                    Console.WriteLine("Clue" + i + ":");
                    var clueInput = Console.ReadLine();
                    Clues.Add(clueInput);
                }
            }
