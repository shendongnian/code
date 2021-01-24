    using System;
    using System.Windows.Forms;
    using System.IO;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Drive.v3;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using System.Threading;
    public partial class Form1 : Form
    {
    // If modifying these scopes, delete your previously saved credentials
    // at ~/.credentials/drive-dotnet-quickstart.json
    static string[] Scopes = { DriveService.Scope.DriveReadonly };
    static string ApplicationName = "Drive API .NET Quickstart";
    public Form1()
    {
        InitializeComponent();
        UserCredential credential;
       
        using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
        {
            string credPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
            credPath = Path.Combine(credPath, ".credentials/drive-dotnet-quickstart.json");
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
            Console.WriteLine("Credential file saved to: " + credPath);
        }
        // Create Drive API service.
        var service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
     //here is your request file id taken from https://drive.google.com/file/d/0B6zj9fZgMGr7dXl3Z3VxSGRadU0/view
        FilesResource.GetRequest getRequest =  service.Files.Get("0B6zj9fZgMGr7dXl3Z3VxSGRadU0");
        getRequest.Fields = "webViewLink";
        Google.Apis.Drive.v3.Data.File file = getRequest.Execute();
       //here is the video link you wanted
        string sourceURL = file.WebViewLink;
        //play the video in Winform
        webBrowser1.Url = new Uri(sourceURL);
    }
    
    }
