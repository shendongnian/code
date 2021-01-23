    //Do invoking here
    public void StartInvokeExample(String data1, String data2)
    {
        Type t = objInstance.GetType();
        object classObject = Activator.CreateInstance(t);
        MethodInfo m = t.GetMethod("thisMethod");
        m.Invoke(classObject, new object[] { data1, data2 });
    }
