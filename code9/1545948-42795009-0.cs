    public class A 
    {
        public class Constants
        {
            public const int ConstantA = 1;
        }
    }
    
    public class B : A 
    {
        public new class Constants : A.Constants
        {
            public const int ConstantB = 2;
        }
    }
