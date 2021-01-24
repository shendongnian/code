     **This you can use  to consume WCF POST:**
          HttpWebRequest req = null;
            HttpWebResponse resp = null;
           string baseAddress = "http://localhost:1910/Service1.svc";
            try
            {
                req = (HttpWebRequest)WebRequest.Create(baseAddress + "/adduser?Username=" + username+ "&Password=" + password);
                req.Method = "POST";
                req.ContentType = "text/xml; encoding = UTF-8";
                using (StreamWriter writer = new StreamWriter(req.GetRequestStream()))
                {
                    writer.WriteLine(your_json_data);
                }
                resp = req.GetResponse() as HttpWebResponse;               
            }
