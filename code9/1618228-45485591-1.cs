    using System;
    using Xamarin.Forms;
    
    namespace App1
    {
        public class ScrollableTabbedPage : TabbedPage
        {
        }
        public class App : Application
        {
            public App()
            {
                var tabbedPage = new ScrollableTabbedPage();
                for (int i = 0; i < 7; i++)
                {
                    tabbedPage.Children.Add(this.GetMyContentPage(i));
                }
    
                MainPage = new NavigationPage(tabbedPage);
            }
    
            private ContentPage GetMyContentPage(int i)
            {
                return new ContentPage
                {
                    Title = "Tab number " + i,
                    Content = new StackLayout
                    {
                        Children = {
                            this.GetMyButton()
                        }
                    }
                };
            }
    
            private Button GetMyButton()
            {
                var myButton = new Button()
                {
                    Text = "Welcome to Xamarin Forms!",
                };
    
                myButton.Command = new Command(() =>
                {
                    myButton.Text = "Start" + DateTime.Now.ToString();
                });
                return myButton;
            }
        }
    }
