    using Xamarin.Forms;
    namespace EmbbedImages.Views
    {
        public partial class AboutPage : ContentPage
        {
            public AboutPage()
            {
                InitializeComponent();
    
                beachImage.Source = ImageSource.FromFile("butterfly.jfif");
            }
        }
    }
