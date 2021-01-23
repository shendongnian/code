    System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Test\\Documents\\Sample.txt");
    while ((line = file.ReadLine()) != null)
    {
         Console.WriteLine(line);
         //increment count instead of setting it everytime
         counter += Regex.Matches(line, "the", RegexOptions.IgnoreCase).Count; 
    }
    Console.WriteLine(counter);
    file.Close();
    // Suspend the screen.
    Console.ReadLine();
