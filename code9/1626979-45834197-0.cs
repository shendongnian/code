    public interface ISomeType
    {
        void SomeMethod();
    }
    public class SomeTypeImpl : ISomeType { ... }
    public class SomeTypeProxy : ISomeType
    {
        public ISomeType Dependency { get; set; }
        public SomeTypeProxy(ISomeType dependency) {
            this.Dependency = dependency;
        }
        public void SomeMethod() => this.Dependency.SomeMethod();
    }
