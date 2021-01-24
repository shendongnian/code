    class MyWC:WebClient
    {
    
       public MyWC() {
           Validate = false;
       }
       
       public bool Validate {get;set;} // yes/no
    
       protected override WebRequest GetWebRequest(Uri url)
       {
            // this is called for each DownloadXXXX call
            var _req = (HttpWebRequest) base.GetWebRequest(url);
           
            // if Validate is true 
            if (Validate) {
                // set the callback on this request
                _req.ServerCertificateValidationCallback  = (s,cert,chain,polErr)=> {
                    // do some check, only allow SE certificates here
                    return cert.Subject.Contains(".stackexchange.com");
                };
            }
            return _req;
        }
    }
