    public class B : A
    {
        //Method 1
        public new string Name { get { return "NameChange"; } }
        //Method 2
        public override string GetName()
        {
            return "NameChange"; // return whatever you want
        }
        protected override void SomeMethod() // override abstract method
        {
            // do something
        }
    }
