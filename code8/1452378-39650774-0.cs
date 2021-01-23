    public class CollectorFactory
    {
        public static ICollector Create(MyCredential credential)
        {
            return new MyCollector(credential);
        }
        public static ICollector Create(OtherCredential credential)
        {
            return new OtherCollector(credential);
        }
    }
    
    public interface ICollector
    {
        void Show();
    }
    public class MyCollector : ICollector 
    {
    
        public MyCredential Credential { get; set; }
    
        public MyCollector(MyCredential credential)
        {
            this.Credential = credential;
        }
    
        public void Show()
        {
            Console.WriteLine(this.Credential.Username);
            Console.WriteLine(this.Credential.AuthToken);
        }
    }
    
    public class MyCredential : ICredential
    {
        public string Username{ get; set;  }
    
        public string AuthToken { get; set; }
    }
    
    public interface ICredential
    {
    
    }
