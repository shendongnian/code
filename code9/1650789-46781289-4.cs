    static void outType(object returnValue)
    {
        dynamic task = returnValue as Task;
        if ( task != null )
        {
            var gargs = returnValue.GetType().GenericTypeArguments;
            if (gargs.Count() == 0)
            {
                Console.WriteLine("Task");
            }
            else
            {
                var result = task.IsCompleted ? task.Result : "[Not Complete]";
                Console.WriteLine("Task<{0}> : {1}", gargs[0].Name, result);
            }
        }
    }
