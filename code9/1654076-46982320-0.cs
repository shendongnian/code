    class Program
    {
        static void Main(string[] args)
        {
            /* Copy files from current folder to c:\testa\ */
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ApplicationBase = @"c:\testa\";
            domaininfo.PrivateBinPath = @"c:\testa\";
            Evidence adevidence = AppDomain.CurrentDomain.Evidence;
            AppDomain domain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo);
    
            Type type = typeof(Proxy);
            var value = (Proxy)domain.CreateInstanceAndUnwrap(
                type.Assembly.FullName,
                type.FullName);
    
            var assembly = value.Run(() => { /* My Program */});
            
        }
    }
    
    public class Proxy : MarshalByRefObject
    {
        public void GetAssembly(Action a)
        {
            a();
        }
    }
