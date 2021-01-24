    namespace WebServicesApp.Models
    {
        public class FilingViewModel
       {
         public FilingViewModel() {
           this.filing = new Filing();
           this.filingMaster = new FilingMaster();
         }
    
         public Filing filing {get;set;}
         public FilingMaster filingMaster  {get;set;}
       }
    }
