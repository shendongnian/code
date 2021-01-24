    int count = 50000000;
    var FirstNames = Enumerable.Range(0, count).Select(x=>x.ToString());
    var LastNames = Enumerable.Range(0, count).Select(x=>x.ToString());
    var BirthDates = Enumerable.Range(0, count).Select(x=> DateTime.Now.AddSeconds(x));
    
    var sw = new Stopwatch();
    sw.Start();
    
    var FirstNamesList = FirstNames.ToList(); // Blows up in 32-bit .NET with out of Memory
    var LastNamesList = LastNames.ToList();
    var BirthDatesList = BirthDates.ToList();
    
    var result = Enumerable.Range(0, FirstNamesList.Count())
        .Select(i => new 
                     { 
                         First = FirstNamesList[i], 
                         Last = LastNamesList[i], 
                         Birthdate = BirthDatesList[i] 
                     });
    				 
    result = BirthDatesList.Select((bd, i) => new
    { 
        First = FirstNamesList[i], 
        Last = LastNamesList[i], 
        BirthDate = bd 
    });
    
    foreach(var r in result)
    {
    	var x = r;
    }
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
