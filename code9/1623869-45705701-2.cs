    public interface IFoo
    {
        void Do();   // conflicting name 1
    }
    public interface IBar
    {
        void Do();   // conflicting name 2
    }
    public class FooBar : IFoo, IBar
    {
        void IFoo.Do()    // explicit implementation 1
        {            
        }
        void IBar.Do()    // explicit implementation 1
        {
        }
    }
