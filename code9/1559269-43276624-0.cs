                string parameters = string.Concat("k=","1");
                string url = "http://localhost:50001/Client/Index";
                using (Var wc = new WebClient()){
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded;charset=UTF-8";
                string result = wc.UploadString(url, parameters);
                JObject obj = JObject.Parse(result);
                Console.WriteLine("Result: {0};", obj.data);               
                }`
