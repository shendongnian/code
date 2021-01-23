    public class createGenericClass
    {
        public void CallDoSomeThing(IWebService t, int x, int y)
        {
            t.DoSomeThing(x, y);
        }
        public void CallDoSomeThingElse(IVoiceService t, int a, float b)
        {
            t.DoSomeThingElse(a, b);
        }
    }
