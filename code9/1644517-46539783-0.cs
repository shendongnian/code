    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MBCProductDetails : System.Web.Services.WebService
    { 
        [WebMethod(Description = "This method call will get the product name, interest rate and the account fee for a given product code.", EnableSession = false)]
        public ProductDetails GetProductDetails(int ProductCode)
        {
         ...
        }
        public MBCProductDetails()
        {
         ...
        }
        public struct ProductDetails
        {
          ...
        }
        private ProductDetails Products;
        private void AssignValues(int ProductCode)
        { 
        ...
        }
    }
