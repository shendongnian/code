    public abstract class A<T>
    {
        public void MyFunc() 
        {
            if(this.GetType() == typeof(MyClass))
            {
                // do your magic
            }
        }
    }
    
    public class MyClass : A<string>
    {
    }
