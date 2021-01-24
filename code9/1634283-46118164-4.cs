    using System.Globalization;
    ...
    private static double ReadDouble(string title)
    {
        while (true) 
        {
            Console.WriteLine(title);
    
            string userInput = Console.ReadLine();
    
            double result;
    
            // We use CultureInfo.InvariantCulture to ensure that
            // decimal separator is dot (.). i.e. we expect 5.5 input
            if (double.TryParse(userInput, 
                                NumberStyles.Any, 
                                CultureInfo.InvariantCulture, 
                                out result))
            {
                return result;
            }
            Console.WriteLine("Sorry, incorrect format. Enter it again, please.");  
        }
    }
    
