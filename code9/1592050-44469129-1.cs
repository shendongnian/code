    File.ReadLines("PathOfYourFile").Sum(line => 
        {
            int possibleNumber;
            if (int.TryParse(line, out possibleNumber)
            {
                // success so return the number
                return possibleNumber;
            }
            else
            {
                // Maybe log the line number or throw the exception to 
                // stop processing the file or 
                // return a zero and continue processing the file
                return 0; 
            }
        }
 
