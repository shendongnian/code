    public class FindMedian
    {
        public List<int> numbersList = new List<int>(); // list to store user input
        // constructor 
        public FindMedian(int n)
        {
            Console.WriteLine("Please Enter " + n + " numbers. \n\n");
            for (int i = 1; i < n + 1; i++)
            {
                Console.WriteLine("Number " + i + " : ");
                numbersList.Add(GetUserInput()); // call's GetUserInput
            }
            PrintData();
        }
        // returns int from Console. Will continue to run until a valid int is entered 
        private int GetUserInput() 
        {
            int temp = 0;
            bool numberValid = false;
            while (!numberValid)
            {
				try
				{
                    temp = int.Parse(Console.ReadLine());
                    numberValid = true;
				}
				catch
				{
                    Console.WriteLine("Invalid entry. Please try again.\n");
                    numberValid = false;
				}
            }
            return temp;
        }
        // prints data after user enteres the correct number of ints 
        private void PrintData()
        {
            // If list contains no data
            if (numbersList.Count < 3)
            {
                Console.WriteLine("No User Data Entered");
                return;
            }
            numbersList.Sort(); // Sorts list from smallest to largest
            int minimum = numbersList[0];
            int median;
			// if list count is even and median is average of two middle numbers
			if (numbersList.Count % 2 == 0)
            {
                median = (numbersList[(numbersList.Count / 2) - 2] + numbersList[(numbersList.Count / 2) - 1] / 2);
            }
            // if list count is odd and median is just middle number
            else 
            {
                median = numbersList[(numbersList.Count / 2)];
            }
            Console.WriteLine("Minimum Number : " + minimum);
            Console.WriteLine("Median Number : " + median);
        }
    }
