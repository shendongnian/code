        Regex re = new Regex(@"\d+"); // \d+ is used to find integers 
        Match m = re.Match("test 66"); // string with inegers
        // check if result is true and output it
        if (m.Success)
        {
           Console.WriteLine(string.Format("RegEx found " + m.Value + " at position " + m.Index.ToString()));
        }
        else
        {
            Console.WriteLine("You didn't enter a string containing a number!");
        }
