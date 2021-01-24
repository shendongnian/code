    public class MyClass
    {
        public void Foo()
        {
            try
            {
                //Execute some code that might fail
            }
            catch
            {
                bar();
                throw;
            }
        }
        private void bar()
        {
            //do something before throwing
        }
    }
