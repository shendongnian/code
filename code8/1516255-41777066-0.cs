    public class MyClass1
    {
        public IList<MyPropertyClass1> Property1{get; protected set;}
        public MyPropertyClass2 Property2{get; protected set;}
        ...
    
        public MyClass1()
        {
            //I initialize Property1 by empty List<T>=> internal logic will not crashed if user try to set Property1 as null.
            Property1=new List<MyPropertyClass1>();
            Property2=default(MyPropertyClass2);
            ...
        }
        
        public MyClass1(IList<MyPropertyClass1> property1, MyPropertyClass2 property2)
            :this()
        {
            if(property1!=null)
            {
                Property1=property1;
            }
            if(property2!=default(MyPropertyClass2))
            {
                Property2=property2;
            }
        }
    }
