    try
    {
        
        DateTime date = DateTime.Parse(inputDate);
        Console.WriteLine(date+"\n");
        string month = date.Month.ToString();
        string day = date.Day.ToString();
        string year = date.Year.ToString();
        string resultingString = month + " " + day + " " + year ;
        Console.WriteLine(resultingString);
    }
    catch(Exception e)
    {
        //Exceptions. String not valid because ambiguity
        Console.WriteLine("Ambiguous");
    }
