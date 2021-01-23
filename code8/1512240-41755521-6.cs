    public class MainPage : ContentPage, IMyPage
    {
        public static readonly BindableProperty MessageProperty = BindableProperty.Create( nameof( Message ), typeof( string ), typeof( MainPage ), string.Empty );
        public string Message
        {
            get { return (string)GetProperty( MessageProperty ); }
            set { SetProperty( MessageProperty, value ); }
        }
    }
    
