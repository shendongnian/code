    public class MasterPage : ContentPage
    {
        public MasterPage()
        {
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "This is the Master page!" }
                }
            }
        }
    }
    public class DetailPage : ContentPage
    {
        public DetailPage()
        {
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = "This is the Detail page!" }
                }
            }
        }
    }
    // And in the App constructor
    MainPage = new MasterDetailPage
    {
        Master = new MasterPage(),
        Detail = new DetailPage()
    };
