     string searchStr= "the";
     List<string> totalMatchStrings = new List<string>();
     while ((line = file.ReadLine()) != null)
     {
         totalMatchStrings.AddRange(lineInput.Split(' ').Where(x => x.ToLower().Contains(searchString)));         
     }
     string matchingWords = String.Join(",", totalMatchStrings.Distinct());
     Console.WriteLine("Occurance of {0} in this document is {1}",searchStr,totalMatchStrings.Count);
     Console.WriteLine("matching words are : {0}",matchingWords );
