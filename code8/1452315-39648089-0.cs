     static void Main(string[] args)
        {
            Console.WriteLine("Enter a number and click enter, continue doing this process ");
            Console.WriteLine("When you finish, just click enter without giving any input");
            int i = 0;
            int[] numbersArray = new []{1};
            List<int> numbersList = new List<int>();
            while (true)
            {
                String numInput = Console.ReadLine();
                if (numInput == null || !numInput.All(char.IsDigit)) continue;
                if (numInput != "")
                {
                    numbersList.Add(Int32.Parse(numInput));
                    numbersArray = numbersList.ToArray();
                    if (i >= 1)
                    {
                        if (numbersArray[i] < numbersArray[i - 1])
                        {
                            Console.WriteLine("Your series is not going up!");
                            break;
                            Environment.Exit(0); // <-- Code is unreachable!
                        }
                    }
                i++;
                }
                else if(i >= 1)
                {
                    break;
                }
            }
            Console.WriteLine("You entered this series: ");
            foreach (int t in numbersArray)
            {
                Console.WriteLine(" " + t);
            }
            Console.WriteLine("The length of the series youve entered is: " + numbersArray.Length);
            Console.ReadLine();
        }
