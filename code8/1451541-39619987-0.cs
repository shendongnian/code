    public class MyClass{
    
        //set this as private/protected/public or nothing and you can also set a default value
        int a;
        public void A()
        {
            a = 4;
            string b = "Hello World";
    
            B(ref vals);
    
            //Or like so
            C(ref current);
        }
    
        public void B(ref AllValues)
        {
            a = 3;
            ...
        }
    
        public void C(ref MethodThatSharesAllValues method)
        {
            a = 3;
            ...
        }
    }
