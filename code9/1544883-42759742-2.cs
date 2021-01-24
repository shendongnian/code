    public interface IHaveSomeMethod {
        bool SomeMethod();
    }
    public class PrivateObject {
        private IHaveSomeMethod dependency;
        public PrivateObject(???SomeObject someObject???, IHaveSomeMethod ihsm) {
            // ...
            this.iHaveSomeMethod = ihsm;
            // ...
        }
        public void DoSometing() {
            // ...
            iHaveSomeMethod.SomeMethod();
            // ...
        }
    }
