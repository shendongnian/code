            bool isClicked = true;
            while(isClicked)
            {
                Console.WriteLine("Please Select An Opion Between 1 To 4:");
                Console.WriteLine("1. ");
                Console.WriteLine("2. ");
                Console.WriteLine("3. ");
                Console.WriteLine("4. ");
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Press Any Key To Return To Main Menu");
                        Console.ReadKey();
                        //isClicked = false;        // Used to suspend the operation
                        break;
                    case 2:
                        // code for option 2 
                        break;
                    case 3:
                        // code for option 3
                        break;
                    case 4:
                        // code for option 4 
                        break;
                    default:
                        Console.WriteLine("Error occured");
                        break;
                }
            }      
