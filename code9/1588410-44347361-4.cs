    public class MyExternalHelperAppService : nsIExternalHelperAppService
    {
         public MyExternalHelperAppService(/* ... */)
         {
            /* ... */
         }
         public nsIStreamListener DoContent(nsACStringBase aMimeContentType, nsIRequest aRequest, nsIInterfaceRequestor aWindowContext, bool aForceSave)
         {
             var request = Request.CreateRequest(aRequest);
             var lChannel = request as HttpChannel;
             try {
                 if (lChannel != null) {
                     var uri = lChannel.OriginalUri;
                     var contentType = lChannel.ContentType;
                     var contentLength = lChannel.ContentLength;
                     var dispositionFilename = lChannel.ContentDispositionFilename;
                     
                     // Do your contenttype validation, keeping only what you need.
                     // Make sure you clean dispositionFilename before using it.
                     
                     // If you don't want to do anything with that file, you can return null;
                     return new MyStreamListener(/* ... */);
                }
            }
            catch (COMException) {
                /* ... */
            }
            return null;
        }
    }
    
