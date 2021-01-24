    static void Main(string[] args)
            {
    
                System.Net.ServicePointManager.ServerCertificateValidationCallback +=
        (se, cert, chain, sslerror) =>
        {
            return true;
        };
    
                string ServiceHostName = "https://111.333.ir/InquiryService.svc";
            string result = "";
                using (WebClient ClientRequest = new WebClient())
                {
                    ClientRequest.Headers["Content-type"] = "application/json";
                    ClientRequest.Encoding = System.Text.Encoding.UTF8;
                    NetworkCredential credential1 = new NetworkCredential("1", "1");
                    ClientRequest.Credentials = credential1;
                    //result = ClientRequest.DownloadString(ServiceHostName + "/" + "2012-12-28" + "/" + "61" + "-" + "921" + "ج" + "25");
                    result = ClientRequest.DownloadString(ServiceHostName + "/Inquiry/2012-12-28" + "/" + "11-365ب12");
                }
    
               // var javascriptserializer = new JavaScriptSerializer();
            }
