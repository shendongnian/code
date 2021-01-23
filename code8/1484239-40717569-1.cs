    private string GetUserInput_Double(string message, int index)
    {
        try
        {
            Write("Please enter wage: ", (i + 1));            
            return Convert.ToDouble(ReadLine());
            //OR
            double result;
            double.TryParse(ReadLine(),out result);
            if(result != 0)
            {
                return result;
            }
        }
        catch(Exception ex) //Catch all thrown Exception
        {
            Write(ex.Message);//Handle Exceptions (log, retry,..)
            return null; //When retunring null check for null when working with the returned value !!!
        }
    }
