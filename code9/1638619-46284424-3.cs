	using System.ComponentModel;
	using RestSharp;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using TechsportiseApp.Views;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;
	using TechsportiseApp.API;
	using TechsportiseApp.ViewModels;
	using TechsportiseApp.Models;
	using Newtonsoft.Json;
	namespace TechsportiseApp.ViewModels
	{
		public class LoginViewModel : INotifyPropertyChanged
		{
			
			public LoginViewModel()
			{
				OnLoginCommand = new Command(ExecuteOnLogin);
			}
			
			private bool _isBusy;
			public bool IsBusy
			{
				get { return _isBusy; }
				set
				{
					if (_isBusy == value)
						return;
					_isBusy = value;
					OnPropertyChanged("IsBusy");
				}
			}
			
			private string _email;
			public string Email
			{
				get { return _email; }
				set
				{
					if (_email == value)
						return;
					_email = value;
					OnPropertyChanged("Email");
				}
			}
			
			private bool _password;
			public bool Password
			{
				get { return _password; }
				set
				{
					if (_password == value)
						return;
					_password = value;
					OnPropertyChanged("Password");
				}
			}
			
			private async void OnLogin()
			{
				//Validations here
				if (Email == "")
				{
					Device.BeginInvokeOnMainThread(() => App.Current.MainPage.DisplayAlert("Validation Error", "You must enter an Email address", "OK"));
					return;
				}
				else if (Password == "")
				{
					Device.BeginInvokeOnMainThread(() => App.Current.MainPage.DisplayAlert("Validation Error", "You must enter a Password", "OK"));
					return;
				}
				//We are good to go
				else
				{
					Device.BeginInvokeOnMainThread(() => IsBusy = true);
					string APIServer = Application.Current.Properties["APIServer"].ToString();
					var client = new RestClient(APIServer);
					var request = new RestRequest("api/account/sign-in", Method.POST);
					request.AddHeader("Content-type", "application/json");
					request.AddJsonBody(new
											{
												email = Email,
												password = Password
											}
										);
					var response = client.Execute(request) as RestResponse;
					Device.BeginInvokeOnMainThread(() => IsBusy = false);
					//Valid response
					if (response.StatusCode.ToString() == "OK")
					{
						var tokenobject = JsonConvert.DeserializeObject<TokenModel>(response.Content);
						Application.Current.Properties["Token"] = tokenobject.Access_token;
						string token = Application.Current.Properties["Token"].ToString();
						App.Current.MainPage = new NavigationPage(new MainPage());
					}
					//Error response
					else
					{
						var statuscode = response.StatusCode.ToString();
						var content = response.Content;
						var exception = response.ErrorException;
						var error = response.ErrorMessage;
						var statusdesc = response.StatusDescription;
						Device.BeginInvokeOnMainThread(() => App.Current.MainPage.DisplayAlert("Login Failed", "Your login has failed. Please check your details and try again.", "OK"));
					}
				}
			}
			
			public event PropertyChangedEventHandler PropertyChanged;
			protected virtual void OnPropertyChanged(string propertyName)
			{
				var changed = PropertyChanged;
				if (changed != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			
			public Command OnLoginCommand {get;}
		}
	}
