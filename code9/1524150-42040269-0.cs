    static void Main()
    {
        string input = Console.ReadLine(); // grab user input in one whole line
        string[] splitted = input.Split(','); // split user input by comma sign ( , )
        int[] a = new int[splitted.Length]; // create a new array that matches user input values length
        for(int i = 0; i < splitted.Length; i++) // iterate through all user input values
        {
            int temp = -1; // create temporary field to hold result 
            int.TryParse(splitted[i], out temp); // check if user inpu value can be parsed into int
            a[i] = temp; // assign parsed int value
        }
    }
