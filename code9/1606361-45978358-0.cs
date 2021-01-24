    public class FirebaseNotificationModel
    {
    	[JsonProperty(PropertyName = "to")]
    	public string To { get; set; }
    
    	[JsonProperty(PropertyName = "notification")]
    	public NotificationModel Notification { get; set; }
    }
    
    
    using System.Net.Http;
    using System.Text;
    public static async void Send(FirebaseNotificationModel firebaseModel)
    {
    	HttpRequestMessage httpRequest = null;
    	HttpClient httpClient = null;
    
    	var authorizationKey = string.Format("key={0}", "YourFirebaseServerKey");
    	var jsonBody = SerializationHelper.SerializeObject(firebaseModel);
    
    	try
    	{
    		httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send");
    
    		httpRequest.Headers.TryAddWithoutValidation("Authorization", authorizationKey);
    		httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
    
    		httpClient = new HttpClient();
    		using (await httpClient.SendAsync(httpRequest))
    		{
    		}
    	}
    	catch
    	{
    		throw;
    	}
    	finally
    	{
    		httpRequest.Dispose();
    		httpClient.Dispose();
    	}
    }
