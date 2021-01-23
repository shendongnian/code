    System.IO.StreamReader file = new System.IO.StreamReader("e:\\file.txt", false);
    System.IO.StreamWriter resultFile = new System.IO.StreamWriter("e:\\resultFile.txt");
    while ((line = file.ReadLine()) != null)
    {
        if (line.Contains("<="))
        {
            resultFile.WriteLine(Environment.NewLine + counter.ToString() + ": " + line);                    
        }
        // if you don't want to write lines without "<=" - delete "else" block
        else
        {
            resultFile.WriteLine(counter.ToString() + ": " + line);    
        }
        counter++;
    }
