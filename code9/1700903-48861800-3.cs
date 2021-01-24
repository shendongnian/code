    public class UserPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        //Just a class with details like name,age etc.
        public UserModel Model { get; set; }
        public UserPrincipal(UserModel model)
        {
            this.Model = model;
            this.Identity = new GenericIdentity(model.Email);
        }        
    }
