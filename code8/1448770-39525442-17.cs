    public class createGenericClass<T, V>
        where T: IWebService
        where V: IVoiceService
    {
        public void CallDoSomeThing(T t, int x, int y)
        {
            t.DoSomeThing(x, y);
        }
        public void CallDoSomeThingElse(V t, int a, float b)
        {
            t.DoSomeThingElse(a, b);
        }
    }
