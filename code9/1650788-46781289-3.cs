    static void outType(object returnValue)
    {
        var task = returnValue as Task;
        if ( task != null )
        {
            var gargs = returnValue.GetType().GenericTypeArguments;
            if (gargs.Count() == 0)
                Console.WriteLine("Task");
            else
            {
                var prop = returnValue.GetType().GetProperty("Result");
                var result = task.IsCompleted ? prop.GetValue(returnValue) : "[Not Complete]";
                Console.WriteLine("Task<" + gargs[0].Name + "> " + result);
            }
        }
    }
 
