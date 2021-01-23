    try
    {
        System.Reflection.Assembly dll1 =  System.Reflection.Assembly.LoadFile("Dll1.dll");
        if (dll1 != null)
        {
            object obj = dll1.CreateInstance("Func1Cls");
            if (obj != null)
            {
                System.Reflection.MethodInfo mi = obj.GetType().GetMethod("func1");
                mi.Invoke(obj, new object[0]);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
