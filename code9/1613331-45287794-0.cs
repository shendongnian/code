    public class NoLocalFile: IWebRequestCreate
    {
        public WebRequest Create(Uri uri)
        {
                // add your own extra checks here
                // for example what Patrick offered in his answer
                // I didn't test if I can't create a local UNC path
                if (uri.IsFile && !uri.IsUnc)
                {
                    // this is a local file request, we're going to return something safe by 
                    // creating our own custom WebRequest
                    return (WebRequest) new NoLocalFileRequest(); 
                }
                else
                {
                    // this should allow non local file request
                    // if needed
                    return FileWebRequest.Create(uri);
                }
        }
    }
