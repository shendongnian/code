    public static void DisplayParams(params object[] parameters)
    {
        foreach(var param in parameters)
        {
            var arr = param as string[];
            if( arr  != null)
            {
                foreach(var value in arr)
                {
                    Console.WriteLine( value );
                }
            }
            else
            { 
                Console.WriteLine( param );
            }
        }
    }
