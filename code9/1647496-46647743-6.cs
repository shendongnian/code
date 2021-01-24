    void Main()
    {
    		IList<MyAbstractClass> list = new List<MyAbstractClass>();
    		list.Add(new MyImpClass());
    		list[0].GetValue("Testing...");
    }
