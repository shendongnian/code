    using Google.Apis.Authentication;
    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;
    
    using System.Net;
    // ...
    
    public class MyClass {
    
      // ...
    
      /// <summary>
      /// Print a file's metadata.
      /// </summary>
      /// <param name="service">Drive API service instance.</param>
      /// <param name="fileId">ID of the file to print metadata for.</param>
      public static void printFile(DriveService service, String fileId) {
        try {
          File file = service.Files.Get(fileId).Execute();
    
          Console.WriteLine("Title: " + file.Title);
          Console.WriteLine("Description: " + file.Description);
          Console.WriteLine("MIME type: " + file.MimeType);
        } catch (Exception e) {
          Console.WriteLine("An error occurred: " + e.Message);
        }
      }
    
      /// <summary>
      /// Download a file and return a string with its content.
      /// </summary>
      /// <param name="authenticator">
      /// Authenticator responsible for creating authorized web requests.
      /// </param>
      /// <param name="file">Drive File instance.</param>
      /// <returns>File's content if successful, null otherwise.</returns>
      public static System.IO.Stream DownloadFile(
          IAuthenticator authenticator, File file) {
        if (!String.IsNullOrEmpty(file.DownloadUrl)) {
          try {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                new Uri(file.DownloadUrl));
            authenticator.ApplyAuthenticationToRequest(request);
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK) {
              return response.GetResponseStream();
            } else {
              Console.WriteLine(
                  "An error occurred: " + response.StatusDescription);
              return null;
            }
          } catch (Exception e) {
            Console.WriteLine("An error occurred: " + e.Message);
            return null;
          }
        } else {
          // The file doesn't have any content stored on Drive.
          return null;
        }
      }
    
      //...
    
    }
