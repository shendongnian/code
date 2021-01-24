    string storageAccount = "storageAccount";
            string accessKey = "accessKey";
            string resourcePath = "TableSample()";
            string uri = @"https://" + storageAccount + ".table.core.windows.net/" + resourcePath;
            // Web request 
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json;odata=nometadata";
            request.Headers["x-ms-date"] = DateTime.UtcNow.ToString("R", System.Globalization.CultureInfo.InvariantCulture);
            request.Headers["x-ms-version"] = "2015-04-05";
            string stringToSign = request.Headers["x-ms-date"] + "\n"; 
            int query = resourcePath.IndexOf("?");
            if (query > 0)
            {
                resourcePath = resourcePath.Substring(0, query);
            }
            stringToSign += "/" + storageAccount + "/" + resourcePath;
            System.Security.Cryptography.HMACSHA256 hasher = new System.Security.Cryptography.HMACSHA256(Convert.FromBase64String(accessKey));
            string strAuthorization = "SharedKeyLite " + storageAccount + ":" + System.Convert.ToBase64String(hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToSign)));
            request.Headers["Authorization"] = strAuthorization;
            Task<WebResponse> response = request.GetResponseAsync();
            HttpWebResponse responseresult = (HttpWebResponse)response.Result;
                using (System.IO.StreamReader r = new System.IO.StreamReader(responseresult.GetResponseStream()))
                {
                    string jsonData = r.ReadToEnd();
                    Console.WriteLine(jsonData);
               }
            Console.ReadLine();
