       public class ReCaptchaResponse
    		{
    			public bool Success;
    			public string ChallengeTs;
    			public string Hostname;
    			public object[] ErrorCodes;
    		}
    
    		[HttpPost]
    		[Route("captcha")]
    		public bool Captcha([FromBody] string token)
    		{
    			bool isHuman = true;
    
    			try
    			{
    				string secretKey = ConfigurationManager.AppSettings["reCaptchaPrivateKey"];
    				Uri uri = new Uri("https://www.google.com/recaptcha/api/siteverify" +
    				                  $"?secret={secretKey}&response={token}");
    				HttpWebRequest request = WebRequest.CreateHttp(uri);
    				request.Method = "POST";
    				request.ContentType = "application/x-www-form-urlencoded";
    				request.ContentLength = 0;
    				HttpWebResponse response = (HttpWebResponse) request.GetResponse();
    				Stream responseStream = response.GetResponseStream();
    				StreamReader streamReader = new StreamReader(responseStream);
    				string result = streamReader.ReadToEnd();
    				ReCaptchaResponse reCaptchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(result);
    				isHuman = reCaptchaResponse.Success;
    			}
    			catch (Exception ex)
    			{
    				Trace.WriteLine("reCaptcha error: " + ex);
    			}
    
    			return isHuman;
    		}
