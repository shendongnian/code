    using System.Web.Services;
    public partial class RFPRegretLetterWP : LayoutsPageBase
    {
        [WebMethod]
        public static IEnumerable GetDDLNames()
        { 
            List<OrderList> list = new List<OrderList>();
            /* your code */
            return list;
        }
        public class OrderList
        {
            /* your code */
        }
    }
