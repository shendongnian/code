    //values to store the delta values in
    decimal deltaX, deltaY, deltaZ;
    //The reader for the text file
    using (var reader = new StreamReader("filename.txt"))
    {
        string line;
        //read file line by line
        while ((line = reader.ReadLine()) != null)
        {
            //Check if line starts with Delta 
            if (line.StartsWith("Delta"))
            {
                //For this line you can split by  '=' and then read the second value in the array, trim the string and parse to a decimal value
                deltaX = decimal.Parse(line.Split(new[] {'='})[1].Trim());
                //move reader to next line as we know it will be DeltaY & repeat
                reader.ReadLine();
                deltaY = decimal.Parse(line.Split(new[] { '=' })[1].Trim());
                reader.ReadLine();
                deltaZ = decimal.Parse(line.Split(new[] { '=' })[1].Trim());
            }
        }
    }
