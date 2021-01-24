    public class Foo
    {
        public int SomeIntProperty 
        { 
            get 
            {    
                return Bar?.SomeIntProperty ?? 0;
            }
    
            set 
            {
                if (Bar != null) 
                {
                    Bar.SomeIntProperty = value;
                }
            }
        }
