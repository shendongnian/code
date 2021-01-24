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
	namespace TechsportiseApp.Views
	{
		public partial class Login : ContentPage
		{
			public Login ()
			{
				InitializeComponent ();
				var viewModel = new LoginViewModel();
				BindingContext = viewModel;
				ToolbarItems.Add(new ToolbarItem("New", "addperson.png", async () =>
				{
					await Navigation.PushAsync(new Register());
				}));
			}
			public string CleanResponse(string reason)
			{
				var str = reason;
				var charsToRemove = new string[] { "[", "]", "{", "}", "\"" };
				foreach (var c in charsToRemove)
				{
					str = str.Replace(c, string.Empty);
				}
				return str;
			}
		}
	}
