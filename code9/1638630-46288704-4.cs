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
            LoginViewModel viewModel;
            public Login ()
            {
                BindingContext = viewModel = new LoginPageViewModel();
                InitializeComponent ();
                ToolbarItems.Add(new ToolbarItem("New", "addperson.png", async () =>
                {
                     await Navigation.PushAsync(new Register());
                }));
             }
        }
    }
