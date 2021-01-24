    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Admin.Directory.directory_v1;
    using Google.Apis.Admin.Directory.directory_v1.Data;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace DirectoryQuickstart
    {
        class Program
        {
            // If modifying these scopes, delete your previously saved credentials
            // at ~/.credentials/admin-directory_v1-dotnet-quickstart.json
            static string[] Scopes = { DirectoryService.Scope.AdminDirectoryUserReadonly };
            static string ApplicationName = "Directory API .NET Quickstart";
    
            static void Main(string[] args)
            {
                UserCredential credential;
    
                using (var stream =
                    new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/admin-directory_v1-dotnet-quickstart.json");
    
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }
    
                // Create Directory API service.
                var service = new DirectoryService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = ApplicationName,
                    });
    
                // Define parameters of request.
                UsersResource.ListRequest request = service.Users.List();
                request.Customer = "my_customer";
                request.MaxResults = 10;
                request.OrderBy = UsersResource.ListRequest.OrderByEnum.Email;
    
                // List users.
                IList<User> users = request.Execute().UsersValue;
                Console.WriteLine("Users:");
                if (users != null && users.Count > 0)
                {
                    foreach (var userItem in users)
                    {
                      Console.WriteLine("{0} ({1})", userItem.PrimaryEmail,
                          userItem.Name.FullName);
                    }
                }
                else
                {
                    Console.WriteLine("No users found.");
                }
                Console.Read();
    
            }
        }
    }
