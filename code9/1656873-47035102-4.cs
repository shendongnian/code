    try
        {
            //mStrToDate and mStrToInt are the variables that contains desired time and integer values in string format
            DateTime myDate = DateTime.ParseExact(mStrToDate, "yyyy-MM-dd HH:mm:ss,fff", System.Globalization.CultureInfo.InvariantCulture);
            //int mIntVar = Convert.ToInt32(mStrToInt);
        
            string line = Console.ReadLine();
            if (!int.TryParse(line, out mIntVar ))
            {
                Console.WriteLine("{0} is not an integer", line);
                // Whatever
            }
        
        }
        catch (FormatException exc)
        {
            Console.WriteLine(exc.Message);//this line must specify the exception source 
        }    
    
       
