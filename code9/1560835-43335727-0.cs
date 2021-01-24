        List<string> lineOutVar = new List<string>();
        using (System.IO.StreamReader readerOne = new System.IO.StreamReader("../../FileIOExtraFiles/DataFieldsLayout.txt"))
        {
            while(readerOne.EndOfStream == false)
            {
                string lineReader = readerOne.ReadLine();
                lineOutVar.Add(lineReader); //add the line to the list of string
            }
        }
        foreach(string line in lineOutVar) //loop through each of the line in the list of string
        {
            Console.WriteLine(line);
        }
