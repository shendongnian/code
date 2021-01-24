    string pattern2 =(((?#********RepeatablePart********)(?<MININUM2>(\d+))\sto\s(?<MAXIMUM2>(\d+|many){1})|(?<MINMAX2>(\d+|many{1}){1}){1})\s(?<TERM3>([A-Z][a-z]{1,})))+\.$
    List<MyObject> myList = new List<MyObject>();
 
    //i = 1 -> since splittedText[0] contains the beginning of the sentence (e.g. 'A Car consists of 2 to 5 Seats')
    for (int i = 1; i<splittedText.Count(); i++)
    {                 
       var match2 = Regex.Match(splittedText[i], pattern2);
       if (match2.Success)
       {                      
           myList.Add(new MyObject()
           {
              term = match2.Groups["TERM3"].Value,              
              min = match2.Groups["MININUM2"].Value,
              max = match2.Groups["MAXIMUM2"].Value,
              minmax = match2.Groups["MINMAX2"].Value
            });
        }
     }
