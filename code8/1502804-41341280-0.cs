    public List<MyClass> GetResults(p1, out string message)
    {
       string message;
       OperatorClass obj= new OperatorClass();
       return obj.GetResults(p1,out message);
    }
