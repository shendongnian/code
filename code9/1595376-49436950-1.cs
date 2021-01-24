    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using Google.Apis.Upload;
    using Google.Apis.Util.Store;
    using Google.Apis.YouTube.v3;
    using Google.Apis.YouTube.v3.Data;
    using Google.Apis.Auth.OAuth2.Flows;
    using Google.Apis.Auth.OAuth2.Responses;
    
    public partial class _Default : System.Web.UI.Page
    {
        string vID = "none";
        public void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void saveDetails_click(object sender, EventArgs e)
        {
            if (Path.GetFileName(videoUpload.PostedFile.FileName) != "")
            {
                YouTubeUtilities ytU = new YouTubeUtilities("REFRESH", "SECRET", "CLIENT_ID"); // pass in your API codes here
    
                using (var fileStream = videoUpload.PostedFile.InputStream) // the selected post file
                {
                    vID = ytU.UploadVideo(fileStream,videoName.Text,videoDesc.Text,"22",false);
                }
                Response.Write(vID);
            }
    
        }
    }
    public class YouTubeUtilities
    {
        /*
         Instructions to get refresh token:
         * https://stackoverflow.com/questions/5850287/youtube-api-single-user-scenario-with-oauth-uploading-videos/8876027#8876027
         * 
         * When getting client_id and client_secret, use installed application, other (this will make the token a long term token)
         */
        private String CLIENT_ID { get; set; }
        private String CLIENT_SECRET { get; set; }
        private String REFRESH_TOKEN { get; set; }
    
        private String UploadedVideoId { get; set; }
    
        private YouTubeService youtube;
    
        public YouTubeUtilities(String refresh_token, String client_secret, String client_id)
        {
            CLIENT_ID = client_id;
            CLIENT_SECRET = client_secret;
            REFRESH_TOKEN = refresh_token;
    
            youtube = BuildService();
        }
    
        private YouTubeService BuildService()
        {
            ClientSecrets secrets = new ClientSecrets()
            {
                ClientId = CLIENT_ID,
                ClientSecret = CLIENT_SECRET
            };
    
            var token = new TokenResponse { RefreshToken = REFRESH_TOKEN };
            var credentials = new UserCredential(new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = secrets
                }),
                "user",
                token);
    
            var service = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = "TestProject"
            });
    
            //service.HttpClient.Timeout = TimeSpan.FromSeconds(360); // Choose a timeout to your liking
            return service;
        }
    
        public String UploadVideo(Stream stream, String title, String desc, String categoryId, Boolean isPublic)
        {
            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = title;
            video.Snippet.Description = desc;
            video.Snippet.CategoryId = categoryId; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            video.Status = new VideoStatus();
            video.Status.PrivacyStatus = isPublic ? "public" : "unlisted"; // "private" or "public" or unlisted
    
            //var videosInsertRequest = youtube.Videos.Insert(video, "snippet,status", stream, "video/*");
            var videosInsertRequest = youtube.Videos.Insert(video, "snippet,status", stream, "video/*");
            videosInsertRequest.ProgressChanged += insertRequest_ProgressChanged;
            videosInsertRequest.ResponseReceived += insertRequest_ResponseReceived;
    
            videosInsertRequest.Upload();
    
            return UploadedVideoId;
        }
    
        void insertRequest_ResponseReceived(Video video)
        {
            UploadedVideoId = video.Id;
            // video.ID gives you the ID of the Youtube video.
            // you can access the video from
            // http://www.youtube.com/watch?v={video.ID}
        }
    
        void insertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
        {
            // You can handle several status messages here.
            switch (progress.Status)
            {
                case UploadStatus.Failed:
                    UploadedVideoId = "FAILED";
                    break;
                case UploadStatus.Completed:
                    break;
                default:
                    break;
            }
        }
    }
