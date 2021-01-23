    internal class DownloadSomeBusinessObject : AbstractDownloadMethod<SomeBusinessObject>
    {
       public DownloadSomeBusinessObject (Action<IEnumerable> handler, string webServiceBaseURL, LoginCredential credential) 
          : base(handler, webServiceBaseURL, credential)
       {
          ActionURL = @"someBusinessObject/";
       }
    }
