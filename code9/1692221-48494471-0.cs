	using Google.Apis.Auth.OAuth2;
	using Google.Apis.Drive.v3;
	using Google.Apis.Services;
	using Google.Apis.Util.Store;
	using System;
	using System.IO;
	using System.Text;
	using System.Threading;
	namespace ConsoleApp3
	{
		internal class Program
		{
			// If modifying these scopes, delete your previously saved credentials
			// at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
			private static string[] Scopes = { DriveService.Scope.Drive };
			private static string ApplicationName = "CsvTest";
			private static void Main(string[] args)
			{
				UserCredential credential;
				using (var stream =
					new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
				{
					string credPath = System.Environment.GetFolderPath(
						System.Environment.SpecialFolder.Personal);
					credPath = Path.Combine(credPath, ".credentials/drive.googleapis.com1.json");
					credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
						GoogleClientSecrets.Load(stream).Secrets,
						Scopes,
						"user",
						CancellationToken.None,
						new FileDataStore(credPath, true)).Result;
					Console.WriteLine("Credential file saved to: " + credPath);
				}
				// Create Google Sheets API service.
				var service = new DriveService(new BaseClientService.Initializer()
				{
					HttpClientInitializer = credential,
					ApplicationName = ApplicationName,
				});
				var fileMetadata = new Google.Apis.Drive.v3.Data.File()
				{
					Name = "My Report",
					MimeType = "application/vnd.google-apps.spreadsheet"
				};
				var csv = "Heading1,Heading2,Heading3\r\nEntry1,Entry2,Entry3";
				FilesResource.CreateMediaUpload request;
				using (var stream = new System.IO.MemoryStream(Encoding.ASCII.GetBytes(csv)))
				{
					request = service.Files.Create(
						fileMetadata, stream, "text/csv");
					request.Fields = "id";
					request.Upload();
				}
				var file = request.ResponseBody;
				Console.WriteLine("File ID: " + file.Id);
				Console.Read();
			}
		}
	}
