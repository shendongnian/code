        public static void UploadBlobWithRestAPI()
        {
            string storageKey = "ffFJwPXTqyYvRoubNQEti/aQUUMwn41BG3KDtl/yGpG4DR1eKaHRq6Bhbw==";
            string storageAccount = "xyz";
            string containerName = "notes";
            string blobName = "test567";
            string method = "PUT";
            string sampleContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla id euismod urna. Maecenas scelerisque dolor purus, sed ullamcorper ipsum lobortis non. Nulla est justo, sodales at venenatis a, faucibus";
            int contentLength = Encoding.UTF8.GetByteCount(sampleContent);
            string requestUri = $"https://xyz.blob.core.windows.net/notes/test567";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            string now = DateTime.UtcNow.ToString("R");
            request.Method = method;
            request.ContentType = "text/plain; charset=UTF-8";
            request.ContentLength = contentLength;
            request.Headers.Add("x-ms-version", "2017-04-17");
            request.Headers.Add("x-ms-date", now);
            request.Headers.Add("x-ms-blob-type", "BlockBlob");
            request.Headers.Add("Authorization", AuthorizationHeader2(method, now, request, storageAccount, storageKey, containerName, blobName));
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(Encoding.UTF8.GetBytes(sampleContent), 0, contentLength);
            }
            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                Console.WriteLine(resp.StatusCode.ToString());
                Console.ReadKey();
            }
        }
        public static string AuthorizationHeader2(string method, string now, HttpWebRequest request, string storageAccount,
            string storageKey, string containerName, string blobName)
        {
            string headerResource = $"x-ms-blob-type:BlockBlob\nx-ms-date:" + now + "\nx-ms-version:2017-04-17";
            string urlResource = "/xyz/notes/test567";
            string stringToSign = method + "\n\n\n" + request.ContentLength +
                "\n\n" + request.ContentType + "\n\n\n\n\n\n\n" + headerResource + "\n" + urlResource;
            HMACSHA256 hmac = new HMACSHA256(Convert.FromBase64String(storageKey));
            string signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            String AuthorizationHeader = String.Format("{0} {1}:{2}", "SharedKey", storageAccount, signature);
            return AuthorizationHeader;
        }
