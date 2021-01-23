    public interface ITenant{
       List<string> GetPhotoUrls();
    }
    public class TenantA:ITenant{
       public List<string> GetPhotoUrls(){
             ...
       }
    }
    public class TenantB:ITenant{
       public List<string> GetPhotoUrls(){
             ...
       }
    }
    public class TenantProcessor{
       public TenantProcessor(ITenant tenant){
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
