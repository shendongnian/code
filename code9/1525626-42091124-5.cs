    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Drive.v3;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    
    namespace GoogleDriveSample
    {
        internal class GoogleDriveFileListDirectoryStructure
        {
            /// <summary>
            /// Authenticate to Google Using Oauth2
            /// Documentation https://developers.google.com/accounts/docs/OAuth2
            /// Credentials are stored in System.Environment.SpecialFolder.Personal
            /// </summary>
            /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
            /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
            /// <param name="userName">Identifying string for the user who is being authentcated.</param>
            /// <returns>SheetsService used to make requests against the Sheets API</returns>
            public static DriveService AuthenticateOauth(string clientId, string clientSecret, string userName)
            {
                try
                {
                    if (string.IsNullOrEmpty(clientId))
                        throw new ArgumentNullException("clientId");
                    if (string.IsNullOrEmpty(clientSecret))
                        throw new ArgumentNullException("clientSecret");
                    if (string.IsNullOrEmpty(userName))
                        throw new ArgumentNullException("userName");
    
                    // These are the scopes of permissions you need. It is best to request only what you need and not all of them
                    string[] scopes = new string[] { DriveService.Scope.DriveReadonly };     	//View the files in your Google Drive
    
                    var credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    credPath = System.IO.Path.Combine(credPath, ".credentials/apiName");
    
                    // Requesting Authentication or loading previously stored authentication for userName
                    var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                                 , scopes
                                                                                                 , userName
                                                                                                 , CancellationToken.None
                                                                                                 , new FileDataStore(credPath, true)).Result;
                    // Returning the SheetsService
                    return new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Drive Oauth2 Authentication Sample"
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Create Oauth2 account DriveService failed" + ex.Message);
                    throw new Exception("CreateServiceAccountDriveFailed", ex);
                }
            }
    
            public class FilesListOptionalParms
            {
                /// The source of files to list.
                public string Corpus { get; set; }
    
                /// A comma-separated list of sort keys. Valid keys are 'createdTime', 'folder', 'modifiedByMeTime', 'modifiedTime', 'name', 'quotaBytesUsed', 'recency', 'sharedWithMeTime', 'starred', and 'viewedByMeTime'. Each key sorts ascending by default, but may be reversed with the 'desc' modifier. Example usage: ?orderBy=folder,modifiedTime desc,name. Please note that there is a current limitation for users with approximately one million files in which the requested sort order is ignored.
                public string OrderBy { get; set; }
    
                /// The maximum number of files to return per page.
                public int PageSize { get; set; }
    
                /// The token for continuing a previous list request on the next page. This should be set to the value of 'nextPageToken' from the previous response.
                public string PageToken { get; set; }
    
                /// A query for filtering the file results. See the "Search for Files" guide for supported syntax.
                public string Q { get; set; }
    
                /// A comma-separated list of spaces to query within the corpus. Supported values are 'drive', 'appDataFolder' and 'photos'.
                public string Spaces { get; set; }
            }
    
            /// <summary>
            /// Lists or searches files.
            /// Documentation https://developers.google.com/drive/v3/reference/files/list
            /// Generation Note: This does not always build correctly.  Google needs to standardize things I need to figure out which ones are wrong.
            /// </summary>
            /// <param name="service">Authenticated Drive service. </param>
            /// <param name="optional">The optional parameters. </param>
            /// <returns>FileListResponse</returns>
            public static Google.Apis.Drive.v3.Data.FileList ListAll(DriveService service, FilesListOptionalParms optional = null)
            {
                try
                {
                    // Initial validation.
                    if (service == null)
                        throw new ArgumentNullException("service");
    
                    // Building the initial request.
                    var request = service.Files.List();
    
                    // Applying optional parameters to the request.
                    request = (FilesResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);
    
                    var pageStreamer = new Google.Apis.Requests.PageStreamer<Google.Apis.Drive.v3.Data.File, FilesResource.ListRequest, Google.Apis.Drive.v3.Data.FileList, string>(
                                                       (req, token) => request.PageToken = token,
                                                       response => response.NextPageToken,
                                                       response => response.Files);
    
                    var allFiles = new Google.Apis.Drive.v3.Data.FileList();
                    allFiles.Files = new List<Google.Apis.Drive.v3.Data.File>();
    
                    foreach (var result in pageStreamer.Fetch(request))
                    {
                        allFiles.Files.Add(result);
                    }
    
                    return allFiles;
                }
                catch (Exception Ex)
                {
                    throw new Exception("Request Files.List failed.", Ex);
                }
            }
    
            public static void PrettyPrint(DriveService service, Google.Apis.Drive.v3.Data.FileList list, string indent)
            {
                foreach (var item in list.Files.OrderBy(a => a.Name))
                {
                    Console.WriteLine(string.Format("{0}|-{1}", indent, item.Name));
    
                    if (item.MimeType == "application/vnd.google-apps.folder")
                    {
                        var ChildrenFiles = ListAll(service, new FilesListOptionalParms { Q = string.Format("('{0}' in parents)", item.Id), PageSize = 1000 });
                        PrettyPrint(service, ChildrenFiles, indent + "  ");
                    }
                }
            }
        }
    
        public class SampleHelpers
        {
            /// <summary>
            /// Using reflection to apply optional parameters to the request.
            ///
            /// If the optonal parameters are null then we will just return the request as is.
            /// </summary>
            /// <param name="request">The request. </param>
            /// <param name="optional">The optional parameters. </param>
            /// <returns></returns>
            public static object ApplyOptionalParms(object request, object optional)
            {
                if (optional == null)
                    return request;
    
                System.Reflection.PropertyInfo[] optionalProperties = (optional.GetType()).GetProperties();
    
                foreach (System.Reflection.PropertyInfo property in optionalProperties)
                {
                    // Copy value from optional parms to the request.  They should have the same names and datatypes.
                    System.Reflection.PropertyInfo piShared = (request.GetType()).GetProperty(property.Name);
                    piShared.SetValue(request, property.GetValue(optional, null), null);
                }
    
                return request;
            }
        }
    }
