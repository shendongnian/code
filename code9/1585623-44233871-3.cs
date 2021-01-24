    public class Foo
    {
        // The children list is not of type T, but it has been closed with 
        // type SomeClass
        private List<SomeClass> children;
        // Here we are saying this method will work so long as it is called with
        // any T that implements IHasId
        // The class is not generic, but the method is
        public bool IsIdOver100<T>(T hasId) where T : IHasId
        {
            return hasId.Id > 100;
        } 
    }
    public class SomeClass : IHasId
    {
        public int Id { get { /*...code*/ } }
    } 
