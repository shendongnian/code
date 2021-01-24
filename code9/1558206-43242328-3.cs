	public async Task PostPicture (byte [] image)
	{
		try {
			string url = .....;
			var requestContent = new MultipartFormDataContent ();
			ByteArrayContent content = content = new ByteArrayContent (image);
			content.Headers.ContentType = MediaTypeHeaderValue.Parse ("image/jpeg");
			requestContent.Add (content, "file", "post" + DateTime.Now + ".jpg"); // change file name as per your requirements
			string result = await HttpCall.PostMultiPartContent (platform, url, requestContent, null);
			
		} catch (Exception ex) {
			System.Diagnostics.Debug.WriteLine (ex.Message);
		}
	}
    public class HttpCall
    {
        public static async Task<string> PostMultiPartContent (int platform, string url, MultipartFormDataContent content, Action<int> progressAction) // Here you can pass an handler to keep track of the upload % in your UI, I'm passing null above. (Not keeping track)
		{
			try {
				var request = new HttpRequestMessage (HttpMethod.Post, url);
				var progressContent = new ProgressableStreamContent (content, 4096, (sent, total) => {
					var percentCompletion = (int)(((double)sent / total) * 100);
					System.Diagnostics.Debug.WriteLine ("Completion: " + percentCompletion);
					if (progressAction != null)
						progressAction (percentCompletion);
				});
				request.Content = progressContent;
				var client = new HttpClient();
				var response = await client.SendAsync (request);
				string result = await response.Content.ReadAsStringAsync ();
				System.Diagnostics.Debug.WriteLine ("PostAsync: " + result);
				return result;
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine (e.Message);
				return null;
			}
		}
    }
