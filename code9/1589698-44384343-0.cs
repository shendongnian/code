    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            bool lineFound = false;
            string line;
            string roomNumber;
            do
            {
                Console.WriteLine("Enter room number");
                roomNumber = Console.ReadLine();
                // Read the file and display it line by line.             
                System.IO.StreamReader file = new 
                      System.IO.StreamReader("room.txt");
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    if (roomNumber == words[1])
                    {                 
                        Console.WriteLine(line);
                        lineFound = true;
                    }             
                        counter++;
                } 
                if(!lineFound)
                {
                    Console.WriteLine("Invalid room number");
                }
    
                file.Close();
    
            } while(!lineFound);
    
            // Suspend the screen.             
             Console.ReadLine(); 
            }
        }
    }
