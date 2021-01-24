    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    using (var response = request.GetResponse()) {
        using (var responseStream = response.GetResponseStream()) {   
            using (var fileToDownload = new System.IO.FileStream(path,  System.IO.FileMode.Create,  System.IO.FileAccess.ReadWrite)) {
                responseStream.CopyTo(fileToDownload);
            }
        }
    }
