    using Xamarin.Forms;
    
    namespace StackOverflowAwesomeness
    {
        public string MainText { get; set; }
        public partial class SimpleLabelPage : ContentPage
        {
            public SimpleLabelPage ()
            {
                InitializeComponent ();
                MainText = "Hello from bindings!";
                BindingContext = this;
            }
        }
    }
