    static void outType(object returnValue)
    {
        if ( returnValue is Task )
        {
            var gargs = returnValue.GetType().GenericTypeArguments;
            if (gargs.Count() == 0)
                Console.WriteLine("Task");
            else
            {
                var prop = returnValue.GetType().GetProperty("Result");
                Console.WriteLine("Task<" + gargs[0].Name + "> " + prop.GetValue(returnValue));
            }
        }
    }
 
