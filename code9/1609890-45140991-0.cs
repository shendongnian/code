    public static List<String> MakeMyList(List<File> myListOfFiles)
    {
        List<String> outputlist = new List<string>();
        int iterationCounter = 0;
        bool thereWereNamesAdded = true;
        while(thereWereNamesAdded)
        {
            //Increment the counter
            iterationCounter++; 
            //Find the names that still need to be added in this iteration
            List<String> theFileNames = myListOfFiles.Where(x => x.Repeat >= iterationCounter)
                                                     .Select(x => x.FileName)
                                                     .ToList();
            //Add the found names to the loop
            outputlist.AddRange(theFileNames);
            //If no file names were added in this loop,
            //set the boolean to false and exit the iteration
            thereWereNamesAdded = theFileNames.Any();
        }
        return outputlist;
    }
