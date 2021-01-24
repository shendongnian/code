	private void Login()
	{
		Task.Run(() => 
		{
			try
			{
				Device.BeginInvokeOnMainThread(() => IsBusy = true);
				var isvalidemail = GlobalFunctions.IsValidEmail(Email);
				var IsThereConnection = GlobalFunctions.CheckForInternetConnection();
				if (IsThereConnection == false)
					throw new Exception("You cannot login whilst you are offline");
				else if (Email == "")
					throw new Exception("You must enter an email address");
				else if (Password == "")
					throw new Exception("You must enter a password");
				else if (isvalidemail == false)
					throw new Exception("You must enter a valid email address");
				//We are good to go
				else
				{
					var LoginStatus = AccountsAPI.Login(Email, Password);
					if (LoginStatus.Code == "OK")
					{
						var tokenobject = JsonConvert.DeserializeObject<TokenModel>(LoginStatus.Content);
						Application.Current.Properties["Token"] = tokenobject.Access_token;
						Application.Current.Properties["IsRemembered"] = RememberMe;
						string token = Application.Current.Properties["Token"].ToString();
						if ((bool)Application.Current.Properties["ShowHelpOnStartup"] == true)
							Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new StartupHelp(true));
						else
							Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new MainMenuMasterDetail());
					}
					//Error response
					else
						throw new Exception("Your login has failed. Please check your details and try again.");			
				}
			}
			catch(Exception ex)
			{
			
				Device.BeginInvokeOnMainThread(() => 
				{
					ValidationError = ex.Message;
					Invalid = true;
				});
			}
			finally
			{
				Device.BeginInvokeOnMainThread(() => IsBusy = true);
			}
		});
	}
