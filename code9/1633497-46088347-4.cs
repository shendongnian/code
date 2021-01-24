    public class AnotherClass
    {
        
        private MyClass _myclass;
        
        public AnoherClass(MyClass myclass)
        {
            _myclass= myclass;
        }
    
        public SomeMethod()
        {
           
           //Use myClass here and you don't need to instantiate it.
           _myclass
           ....
        }
    }
