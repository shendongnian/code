    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;
            string number;
            string letter;
            // this assumes that there will always be only one record??
            bool lineFound;
            string animalType = null;
            string animalColor = null;
            do
            {
                Console.WriteLine("Enter number");
                number = Console.ReadLine();
                Console.WriteLine("\nEnter letter");
                letter = Console.ReadLine();
                System.IO.StreamReader file = new System.IO.StreamReader("animal.txt");
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    // your example data shows the number in position 0 and the letter in position 1
                    if ((number == words[0]) && (letter == words[1]))
                    {
                        Console.WriteLine(line);
                        // assign the found animals type and color to use later
                        animalType = words[3];
                        animalColor = words[2];
                        lineFound = true;
                    }
                    counter++;
                }
                if (!lineFound)
                {
                    Console.WriteLine("Invalid number and/or letter");
                }
                file.Close();
                System.IO.StreamReader habitatFile = new System.IO.StreamReader("habitat.txt");
                // line is being used by two different streams and can create unexpected behavior so instead create a seperate variable
                while ((line = habitatFile.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    // your example data shows the number in position 0 and the letter in position 1
                    if ((animalColor == words[0]) && (animalType == words[1]))
                    {
                        Console.WriteLine(line);
                    }
                }
                habitatFile.Close();
            }
            while (!lineFound);
        }
    }
