    public class DoesSomething
    {
        public void DoSomething(object input)
        {
            if(input is string)
            {
                // Do something
            }
            if(input is Foo)
            {
                // Do something
            }
        }
    }
