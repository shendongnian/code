        public static string RunServerAsync(Action<string> triggerPost)
		{
			var triggerURL = "";
			CommonCode(ref triggerURL);
			if (listener.IsListening)
			{
				triggerPost(triggerURL);
			}
			while (listener.IsListening)
			{
				var context = listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
				context.AsyncWaitHandle.WaitOne(20000, true); //Stop listening after 20 seconds (20 * 1000).
				listener.Close();
			}
			return plateString;
		}
		private static async void TriggerURL(string url)
		{
			var r = await DownloadPage(url);
		}
		static async Task<string> DownloadPage(string url)
		{
			using (var client = new HttpClient())
			{
				using (var r = await client.GetAsync(new Uri(url)))
				{
					if (r.IsSuccessStatusCode)
					{
						string result = await r.Content.ReadAsStringAsync();
						return result;
					}
					else
					{
						return r.StatusCode.ToString();
					}
				}
			}
		}
		private static void ListenerCallback(IAsyncResult result)
		{
			try
			{
				HttpListener listener = (HttpListener)result.AsyncState;
				// Use EndGetContext to complete the asynchronous operation.
				HttpListenerContext context = listener.EndGetContext(result);
				if (context != null)
				{ 
					plateString = ProcessRequest(context);
				}
				else
				{
					plateString = "No response received!";
				}
			}
			catch (Exception ex)
			{
				NLogManager.LogException(ex);
			}
		}
