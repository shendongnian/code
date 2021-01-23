    void UploadBlobWithRestAPI() {
    
        string storageKey = "<your access key here>";
        string storageAccount = "<your storage account name here>";    
        string containerName = "<your container name here>";
        string blobName = "test.txt";
        string method = "PUT";
        string sampleContent = "This is sample text.";
        int contentLength = Encoding.UTF8.GetByteCount(sampleContent);
    
        string requestUri = $"https://{storageAccount}.blob.core.windows.net/{containerName}/{blobName}";
    
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
    
        string now = DateTime.UtcNow.ToString("R");
    
        request.Method = method;
        request.ContentType = "text/plain; charset=UTF-8";
        request.ContentLength = contentLength;
    
        request.Headers.Add("x-ms-version", "2015-12-11");
        request.Headers.Add("x-ms-date", now);
        request.Headers.Add("x-ms-blob-type", "BlockBlob");
        request.Headers.Add("Authorization", AuthorizationHeader(method, now, request, storageAccount, storageKey, "myblobcontainer", blobName));
    
        using (Stream requestStream = request.GetRequestStream()) {
            requestStream.Write(Encoding.UTF8.GetBytes(sampleContent), 0, contentLength);
        }
    
        using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse()) {
            MessageBox.Show(resp.StatusCode.ToString());
        }
    
    }
    
    public string AuthorizationHeader(string method, string now, HttpWebRequest request, string storageAccount, string storageKey, string containerName, string blobName) {
    
        string headerResource = $"x-ms-blob-type:BlockBlob\nx-ms-date:{now}\nx-ms-version:2015-12-11";
        string urlResource = $"/{storageAccount}/{containerName}/{blobName}";
        string stringToSign = $"{method}\n\n\n{request.ContentLength}\n\n{request.ContentType}\n\n\n\n\n\n\n{headerResource}\n{urlResource}";
    
        HMACSHA256 hmac = new HMACSHA256(Convert.FromBase64String(storageKey));
        string signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
    
        String AuthorizationHeader = String.Format("{0} {1}:{2}", "SharedKey", storageAccount, signature);
        return AuthorizationHeader;
    }
