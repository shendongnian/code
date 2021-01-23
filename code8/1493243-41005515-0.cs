    static int GetIDInput()
    {
        int tempID = 0;
        bool taken = true;
        bool isInputValid = false;
        while (taken == true && isInputValid == false)
        {
            Console.WriteLine("Please enter your desired ID number");
            tempID = Convert.ToInt32(Console.ReadLine());
            if (tempID.ToString().Length != 8)
            {
                isInputValid = false;
                Console.WriteLine("ID number must be 8 digits long.")
            }
            if (isInputValid) // this wont run if the input wasnt 8 characters, so the loop will restart
            {
                using (StreamReader sr = new StreamReader("Stockfile.txt"))
                {
                    while (sr.EndOfStream == false && taken != true)
                    {
                        lineValues = sr.ReadLine();
                        if (lineValues.Contains(tempID.ToString()))
                        {
                            taken = true;
                        }
                        else
                        {
                            taken = false;
                        }
                    }
                    if (taken == false)
                    {
                        ID = tempID;
                    }
                    else if (taken == true)
                    {
                        Console.WriteLine("Sorry this ID is already taken, try again");
                        // statements will lead us back to the while loop and taken == true so it will run again
                    }
                }
            }
        }
        return tempID;
    }
    static void AddStock()
    {
        int stockQuantity = 0;
        double stockPrice = 0.00;
        string stockName = "";
        string s = ""; // Being Lazy here, to convert to when needed.
        int IDNumber = 0;
        string lineValues;
        IDNumber = GetIDInput();
        using (StreamWriter sw = new StreamWriter("Stockfile.txt", true))
        {
            s = IDNumber.ToString();
            sw.Write(s + "\t"); // Will only accept an 8 figure digit so is safe to have a single value here.
            using (StreamWriter sw = new StreamWriter("Stockfile.txt", true))
            {
                s = IDNumber.ToString();
                sw.Write(s + "\t"); // Will only accept an 8 figure digit so is safe to have a single value here.
                while (stockName.Length <= 2) // No fancy brands here......
                {
                    Console.Write("Please enter the name of the stock: ");
                    stockName = Console.ReadLine();
                }
                s = stockName;
                sw.Write(s + "\t");
                while (stockQuantity < 1) // Running a small shop here...
                {
                    Console.Write("Please enter the quanity of stock: ");
                    stockQuantity = Convert.ToInt32(Console.ReadLine());
                }
                s = stockQuantity.ToString();
                sw.Write(s + "\t");
                while (stockPrice < 0.01) // Running a very small shop....
                {
                    Console.Write("Please enter the price of the stock: ");
                    stockPrice = Convert.ToDouble(Console.ReadLine());
                }
                s = stockPrice.ToString();
                sw.Write(s + "\t");
                sw.WriteLine(); // TO create the new line.....
            }
