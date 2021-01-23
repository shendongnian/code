    public interface ITenant{
       List<string> GetPhotoUrls();
    }
    public class TenantA:ITenant{
       public string TenantName {get; set;}
       public string TenantUrl {get; set;}
       public List<string> GetPhotoUrls(){
             //A implementation
       }
    }
    public class TenantB:ITenant{
       public string TenantName {get; set;}
       public string TenantUrl {get; set;}  
       public List<string> GetPhotoUrls(){
             //B implementation
       }
    }
    public class SomeTenantApp{
       public SomeTenantApp(ITenant tenant){
          _tenant = tenant;
       }
    
       public void DoSomething(){
         var urls  = _tenant.GetPhotoUrls();
         //do something
       }
    }
    public static class TenantFactory{
        public static ITenant Create(string id)
        {
            //logic to get concrete tenant
            return concreteTenant;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tenant = TenantFactory.Create("A");
            var app = var SomeTenantApp(tenant);
            app.DoSomething();
        }
    }
