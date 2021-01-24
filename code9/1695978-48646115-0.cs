    //note that I used ReadLines, not ReadAllLines
     int lastNumber;
     if(!int.TryParse(File.ReadLines(fileLocation).ToList().Last(), out lastNumber))
     {
          //last value wasn't a valid integer.  Start over. 
          lastNumber = 1;
     }
