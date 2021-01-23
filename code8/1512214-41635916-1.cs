     [WebMethod] attribute must be specified in MyClass.cs testmethod
    
    public class MyClass: System.Web.UI.Page
     {
        [WebMethod]
        public static void Testmethod()
         {
            
            return '';
        }
    }
 
     public  partial class Default: MyClass
    {
    ...
    }
