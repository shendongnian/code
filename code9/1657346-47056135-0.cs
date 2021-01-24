    public class B : A
    {
        public string NameChange => base.GetName();
        protected override void SomeMethod()
        {
            throw new NotImplementedException();
        }
    }
