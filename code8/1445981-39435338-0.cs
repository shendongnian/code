    public class C 
    {
        public void M() 
        {
            C c = new C();
            
            int? result = c?.SomeMethod();
            
            Console.WriteLine(result);
        }
        
        public int SomeMethod()
        {
            return 1;
        }
    }
