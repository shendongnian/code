    static void outType(object returnValue)
    {
        if ( returnValue is Task )
        {
            var gargs = returnValue.GetType().GenericTypeArguments;
            if (gargs.Count() == 0)
                Console.WriteLine("Task");
            else
                Console.WriteLine("Task<" + gargs[0].Name + ">");
        }
    }
 
