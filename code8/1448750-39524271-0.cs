    public class createGenericClassWeb<T> where T : IWebService
    {
        public void CallDoSomeThing(T t, int x, int y)
        {
            t.DoSomeThing(x, y);
        }
    }
    public class createGenericClassVoice<T> where T : IVoiceService
    {
        public void CallDoSomeThingElse(T t, int a, float b)
        {
            t.DoSomeThingElse(a, b);
        }
    }
