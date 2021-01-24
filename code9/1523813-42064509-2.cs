    using Xamarin.Forms;
    
    namespace StackOverflowAwesomeness
    {
        public partial class SimpleLabelPage : ContentPage
        {
            public SimpleLabelPage ()
            {
                InitializeComponent ();
                var pageModel = new SimpleLabelPageModel();
                pageModel.MainText = "Hello from bindings!";
                BindingContext = pageModel;
            }
        }
    }
