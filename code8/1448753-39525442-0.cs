    public class createGenericClass<T> 
        where T : IBaseService
    {
        public void CallDoSomeThing(T t, int x, int y)
        {
            (t as IWebService)?.DoSomeThing(x, y);
        }
    
        public void CallDoSomeThingElse(T t, int a, float b)
        {
            (t as IVoiceService)?.DoSomeThingElse(a, b);
        }
    }
    public interface IBaseService{}
    public interface IWebService : IBaseService
    {
        void DoSomeThing(int x, int y);        
    }
    
    public interface IVoiceService : IBaseService
    {
        void DoSomeThingElse(int a, float b);
    }
