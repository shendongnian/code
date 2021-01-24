    public static void ShowResults(int userInput, List<int> subscripts, int counter)
    {
        //LOOP THROUGH ARRAY
        Console.WriteLine();
        Console.WriteLine("The following students have that grade: ");
        Console.WriteLine();
            if (subscript == -1)
                Console.WriteLine("{0} is NOT in array, # of comparisons is {1}",
                    userInput, counter);
            else
            {
                foreach(var subscript in subscripts)
                {
                    Console.WriteLine("{0} {1}", studentName[subscript].PadRight(20), studentGrade[subscript].ToString().PadRight(5));
                }
            }
    }
