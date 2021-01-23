    public class CollectorFactory<T>
    {
        public T Create(ICredential credential)
        {
            return (T)Activator.CreateInstance(typeof(T), credential);
        }
    }
    public class MyCollector : BaseCollector
    {
        public dynamic Credential { get; private set; }
        public MyCollector(ICredential credential)
            : base(credential)
        {
            this.Credential = credential;
        }
        // Having this methos here limits your ability to make it more generic. 
        // Consider moving this to MyCredential since it refers to specific properties in MyCredential
        public void Show()
        {
            Console.WriteLine(this.Credential.Username);
            Console.WriteLine(this.Credential.AuthToken);
        }
    }
    public class MyCredential : ICredential
    {
        public string Username { get; set; }
        public string AuthToken { get; set; }
    }
    public abstract class BaseCollector : ICredentialCollector
    {
        protected BaseCollector(ICredential credential)
        {
            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }
        }
    }
    public interface ICredentialCollector
    {
    }
    public interface ICredential
    {
    }
    // test implementation
    public class TestClass
    {
        public void AuthFactoryTest()
        {
            // test auth instance
            MyCredential auth = new MyCredential() {AuthToken = "asfgasdgdfg", Username = "xuser"};
            // Create test factory
            var fact = new CollectorFactory<MyCollector>(); 
            var myCollector = fact.Create(auth);
            // Do what you need to do to collector object
            myCollector.Show();
        }
    }
