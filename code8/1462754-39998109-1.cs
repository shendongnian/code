    public static void Sum(string value1, string value2)
    {
        int a;
        int b;
        
        if(Int32.TryParse(value1, out a) && Int32.TryParse(value2, b))
        {
            // If everything is ok, perform some calculations here
            // use a and b as your values
            Console.Log("Sum is: " + (a + b).ToString("N"));
        }
        else
        {
            // If there is an error parsing values, display some error message
            Console.Log("Error parsing value!");
        }
    }
