    static void Main(string[] args)
    {
        string prompt = "Please enter your weight: ";
        Console.Write(prompt + " kg");
        ConsoleKeyInfo keyInfo;
        string weightInput = string.Empty;
        while ((keyInfo = Console.ReadKey()).Key != ConsoleKey.Enter)
        {
            //set position of the cursor to the point where the user inputs wight
            Console.SetCursorPosition(prompt.Length, 0);
            //if a wrong value is entered remove it (optional)
            if (keyInfo.Key.Equals(ConsoleKey.Backspace) && weightInput.Length > 0)
            {
                weightInput = weightInput.Substring(0, weightInput.Length - 1);
            }
            else
            {
                //append typed char to the input before writing it
                weightInput += keyInfo.KeyChar.ToString();
            }
            Console.Write(weightInput + " kg ");
        }
    
        //process weightInput here
    }
