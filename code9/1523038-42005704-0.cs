    public interface IGenericInterface<T> 
    {
         T GetSomething();
         void DoSomething(T arg);
    }
    public class BaseClass : IGenericInterface<int>
    {
         public virtual int GetSomething() { return 5; }
         public virtual void DoSomething(int arg) { Console.WriteLine(arg); }
    }
    public class Derived : BaseClass, IGenericInterface<string>
    {
         string IGenericInterface<string>.GetSomething() { return "hello world!"; }
         public void DoSomething(string arg) { Console.WriteLine(arg); }
    }
