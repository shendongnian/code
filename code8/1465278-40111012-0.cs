    public class MyCustomClass
    {
        public MyCustomClass()
        {
            // BAD CODE, do not do this
            Method1();
        }
        private async Task Method1()
        {
            //do some stuff
            await Method2();
            //do some more stuff
        }
    }
