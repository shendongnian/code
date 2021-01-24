    static void Main(string[] args)
            {
                using (var http = new WebClient())
                {
                    string url = string.Format("{0}api/FileUpload/FileServe?FileID={1}",webApiUrl, FileId);
                    var response = http.OpenRead(url);
                    var fs = new FileStream(String.Format(@"C:\Users\Bailey Miller\Downloads\{0}", GetName(http.ResponseHeaders)), FileMode.Create);
                    response.CopyTo(fs); <-- how to move the stream to the actual file, this is not perfect and there are a lot of better examples
                fs.Flush();
                fs.Close();
                }
    
    
            }
    
            private static object GetName(WebHeaderCollection responseHeaders)
            {
    
                var c_type = responseHeaders.GetValues("Content-Type"); //<-- do a switch on this and return a really weird file name with the correct extension for the mime type.
            var cd = responseHeaders.GetValues("Content-Disposition")[0].Replace("\"", ""); <-- this gets the attachment type and filename param, also removes illegal character " from filename if present
            return cd.Substring(cd.IndexOf("=")+1); <-- extracts the file name
            }
