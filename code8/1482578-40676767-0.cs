    protected async Task<String> connect(String URL,WSMethod method,StringContent body)
    {
    		try
			{
				HttpClient client = new HttpClient
				{
					Timeout = TimeSpan.FromSeconds(Variables.SERVERWAITINGTIME)
				};
				if (await controller.getIsInternetAccessAvailable())
				{
					if (Variables.CURRENTUSER != null)
					{
						var authData = String.Format("{0}:{1}:{2}", Variables.CURRENTUSER.Login, Variables.CURRENTUSER.Mdp, Variables.TOKEN);
						var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
						client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
					}
					HttpResponseMessage response = null;
					//////////Verification du type de requete
					if (method == WSMethod.PUT)
						response = await client.PutAsync(URL, body);
					else if (method == WSMethod.POST)
						response = await client.PostAsync(URL, body);
					else
						response = await client.GetAsync(URL);
                     
                    ....
    }
