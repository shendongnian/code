        class Class1
                {
                    public Func<string, int> method1 = new Func<string, int>(x => 3);
                    public Func<int, double> method2 = new Func<int, double>(x => 4.0);
                    public Func<double, bool> method3 = new Func<double, bool>(x => true);
        
                    List<Delegate> methodList = new List<Delegate>();
        
                    public Class1()
                    {
                        methodList.Add(method1);
                        methodList.Add(method2);
                        methodList.Add(method3);
                    }
        
                    public object RunMethods(object param)
                    {
                        foreach(Delegate del in methodList)
                        {
                            param = del.DynamicInvoke(param);
                        }
        
                        return param;
                    }
                }
    
     static void Main(string[] args)
    {
           Class1 obj = new Class1();
           object result = obj.RunMethods("some string");
    }
                
