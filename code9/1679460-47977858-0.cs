    public class A : Control
    {
        static A()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(A), new FrameworkPropertyMetadata(typeof(A)));
        }
    }
    
    public class B : A 
    {
         static B : base()
         {
         }
    }
