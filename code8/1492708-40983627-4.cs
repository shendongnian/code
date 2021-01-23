    // I'd suggest making this "bool" - they already know what the ID number is,
    // so there's no point in returning it back to them
    static int checkIDNumber(int ID)
    {
        // Check the number passed in & then loop through all the lines...
        // If number is taken then output error, because id exists already
        // Else allow the value to be used in the stock system.
        int IDNumber = ID;
        using (StreamReader sr = new StreamReader("Stockfile.txt"))
        {
            string lineValues;
            // In general, you shouldn't explicitly compare to "true" or "false."
            // Just write this as "!sr.EndOfStream"
            while (sr.EndOfStream == false)
            {
                lineValues = sr.ReadLine();
                if (lineValues.Contains(IDNumber.ToString()))
                {
                    // In this case, you don't have to bother checking the rest of the file
                    // since you already know that the ID is taken
                    Console.WriteLine("Id number is currently already taken.");
                }
                else
                {
                    // You actually can't return that at this point - you need to check
                    // the *entire* file before you conclude that it's not a duplicate
                    return IDNumber;
                }
            }
        }
    }
