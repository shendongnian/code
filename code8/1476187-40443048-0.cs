    public class YourObject
    {
        public YourObject()
        {
            // some code
        }
        public void SomeMethod() {}
    }
    public class YourObjectWithExtraLogic : YourObject
    {
        public YourObjectWithExtraLogic() : base()
        {
            // here add some extra logic
        }
    }
