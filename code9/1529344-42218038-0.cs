     var linesInFile = System.IO.File.ReadAllLines(@"C:\Users\Vishnuraj\Desktop\sample.txt").ToList();
    
     var lineOfID = linesInFile.FirstOrDefault(x => x.ToLower().StartsWith("id"));
     if (!String.IsNullOrEmpty(lineOfID))
     {
         int indexOfID = linesInFile.IndexOf(lineOfID);
         if (indexOfID < linesInFile.Count - 1)
         {
             string nameOfPerson = linesInFile[indexOfID + 1]; // will be "David"
             string personId = lineOfID.Substring(3); // will be 12345
         }
     }
