    string input = "100-200;10;2300-3400;34;";
    string[] ranges = input.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string range in ranges)
    {
        string[] numbers = range.Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string number in numbers)
        {
            int parsedNumber;
            if (!Int32.TryParse(number, out parsedNumber))
            {
                //Invalid input
                break; //Or return false...
            }
            //Use parsedNumber here
        }
    }
