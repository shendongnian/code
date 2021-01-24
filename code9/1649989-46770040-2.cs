     public class HomeController : Controller{
         IDataProtector dataProtector;
        
         public HomeController(IDataProtectionProvider provider){
             dataProtector = provider.CreateProtector(GetType().FullName);
         }
        
        [HttpGet]
        public IActionResult Get() {
            int id = 1234;
            string encryptedId = dataProtector.Protect(id.ToString());
            int decryptedId = 0;
            if(int.TryParse(dataProtector.Unprotect(encryptedId), out decryptedId) == false){
                throw new Exception("Invalid cypher text");
            }
            //at this point decryptedId contains the decrypted value.
       }
        
