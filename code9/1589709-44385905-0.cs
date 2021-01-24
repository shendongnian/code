    using Xamarin.Forms;
    
    namespace EmbbedImages.Views
    {
        public partial class AboutPage : ContentPage
        {
            public AboutPage()
            {
                InitializeComponent();
    
                var beachImage = new Image { Aspect = Aspect.AspectFit };
                beachImage.Source = ImageSource.FromFile("butterfly.jfif");
                this.Content = beachImage;    
            }
        }
    }
