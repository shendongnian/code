    string inputLine;
    // Read and display lines from the file until the end of 
    // the file is reached.
    while ((inputLine = sr.ReadLine()) != null)
    {
        if (inputLine.StartsWith("[")) {
            continue;
        }
        Console.WriteLine(inputLine);
        {
            string[] values = inputLine.Split(new Char[] { '=' });
            Console.WriteLine(values[0]);
            Console.WriteLine(values[1]);
        }
    }
