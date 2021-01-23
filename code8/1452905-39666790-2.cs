    public class SomeClass
    {
        public void SomeMethod() => 
            SomeMethod(() => Guid.NewGuid().ToString())
        public void SomeMethod(Func<string> createId)
        {
            var id = createId();
            // do something
        }
    }
