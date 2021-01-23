    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Web.Script.Serialization;
    
    namespace Chinenye
    {
        class Program
        {
            static void Main()
            {
                var objectString = "{\"currencyCode\":\"CAD\",\"id\":\"29BKR08JSRJ5BE11LD\",\"link\":[{\"rel\":\"hosted_payment\",\"uri\":\"https://pay.test.netbanx.com/hosted/v1/payment/53616c7465645f5fcb770fe4ad39262c27ae2fba4189e1ef89aacc3fac4e0fc0ba7d1699c4a50672\"},{\"rel\":\"self\",\"uri\":\"https...\"},{\"rel\":\"resend_callback\",\"uri\":\"https://37520-1001043850:B-qa2-0-56797b63-0-302c02147c32c6cad7f273be1c06cc7377a22520ce4d31af0214541d250968177ad25a4041ef9c039accca483132@api.test.netbanx.com/hosted/v1/orders/29BKR08JSRJ5BE11LD/resend_callback\"}],\"merchantRefNum\":\"fd63cb9d-b586-664d-9bba-8492baf4bad9\",\"mode\":\"live\",\"totalAmount\":\"100\",\"type\":\"order\"}";
    
                JavaScriptSerializer serializer = new JavaScriptSerializer();
    
                var o = serializer.Deserialize<HttpObject>(objectString);
    
                Debugger.Break();
            }
        }
    
        class HttpObject
        {
            public string currencyCode;
            public string id;
            public List<Link> link;
            public string merchantRefNum;
            public string mode;
            public string totalAmount;
            public string type;
        }
    
        class Link
        {
            public string rel;
            public string uri;       
        }
    }
    
