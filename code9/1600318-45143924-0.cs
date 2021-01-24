			try
			{
				//Scopes for use with the Google Drive API
				string[] scopes = new string[] { 
								 DriveService.Scope.DriveFile};
				var clientId = "Create auth0 Id and copy here";      // From https://console.developers.google.com
				var clientSecret = "";          // From https://console.developers.google.com
				// here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
				GoogleWebAuthorizationBroker.Folder = "Drive.Sample";
				var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
				{
					ClientId = clientId,
					ClientSecret = clientSecret
				},
				scopes,
				"Admin",
				CancellationToken.None,
				new FileDataStore("Daimto.GoogleDrive.Auth.Store")).Result;
				var service = new DriveService(new BaseClientService.Initializer()
				{
					HttpClientInitializer = credential,
					ApplicationName = "Drive API Sample",
				});
				uploadFile(service, "d:\\bmjo\\EastManTemp.xml", "0B1HV_LVO8x0zSWFrRkE2LVFUQ2c");
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message, "Error");
			}
		}
		// tries to figure out the mime type of the file.
		private static string GetMimeType(string fileName)
		{
			string mimeType = "application/unknown";
			string ext = System.IO.Path.GetExtension(fileName).ToLower();
			Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
			if (regKey != null && regKey.GetValue("Content Type") != null)
				mimeType = regKey.GetValue("Content Type").ToString();
			return mimeType;
		}
		public static File uploadFile(DriveService _service, string _uploadFile, string _parent)
		{
			if (System.IO.File.Exists(_uploadFile))
			{
				File body = new File();
				
				body.Title = System.IO.Path.GetFileName(_uploadFile);
				body.Description = "File uploaded by Diamto Drive Sample";
				body.MimeType = GetMimeType(_uploadFile);
				body.Parents = new List<ParentReference>();// { new ParentReference() { Id = _parent } };
				body.Parents.Add(new ParentReference() { Id = _parent });
				// File's content.
				byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
				System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
				try
				{
					FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, GetMimeType(_uploadFile));
					request.Upload();
					return request.ResponseBody;
				}
				catch (Exception e)
				{
					Console.WriteLine("An error occurred: " + e.Message);
					return null;
				}
			}
			else
			{
				Console.WriteLine("File does not exist: " + _uploadFile);
				return null;
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(new ThreadStart(GoogleThread));
			thread.Start();
		}
