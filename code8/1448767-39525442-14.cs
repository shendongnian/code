    public class createGenericClass<T> 
        where T : IBaseService // telling T can be only IBaseService and inherited stuff.
    {
        public void CallDoSomeThing(T t, int x, int y)
        {
            (t as IWebService)?.DoSomeThing(x, y); // casting and validating
        }
    
        public void CallDoSomeThingElse(T t, int a, float b)
        {
            (t as IVoiceService)?.DoSomeThingElse(a, b); // casting and validating
        }
    }
    public interface IBaseService{} // only gives a common parent to other interfaces. Common properties, methods can be included here.
    public interface IWebService : IBaseService // inheriting the common interface
    {
        void DoSomeThing(int x, int y);        
    }
    
    public interface IVoiceService : IBaseService // inheriting the common interface
    {
        void DoSomeThingElse(int a, float b);
    }
