    public class ImageButton : Grid
    // A clickable visual element overlaying a label on an image, serving as a button
    {
        public event EventHandler Clicked;
        public Image TheImage { get; set; }
        public Label TheLabel { get; set; }
        public bool HideKeyboard { get; set; }
        public string Text
        { 
            get
            {
                if ( TheLabel == null )
                    return null;
                return TheLabel.Text;
            }
            set
            {
                if ( TheLabel == null )
                    return;
                TheLabel.Text = value;
            }
        }
        public Color TextColor 
        {
            set
            {
                if ( TheLabel != null )
                    TheLabel.TextColor = value;
            }
        }
        public string FontFamily 
        {
            set 
            {
                if ( TheLabel != null )
                    TheLabel.FontFamily = value;
            }
        }
        public FontAttributes FontAttributes 
        {
            set 
            {
                if ( TheLabel != null )
                    TheLabel.FontAttributes = value;
            }
        }
        public double FontSize 
        {
            set 
            {
                if ( TheLabel != null )
                    TheLabel.FontSize = value;
            }
        }
        public double ImageHeightRequest
        {
            set
            {
                if ( TheImage != null )
                    TheImage.HeightRequest = value;
            }
        }
        public double ImageWidthRequest
        {
            set
            {
                if ( TheImage != null )
                    TheImage.WidthRequest = value;    
            }
        }
        public ImageButton ( Image image, Label label, bool hideKeyboard = true )
        {
            TheImage = image;
            TheLabel = label;
            HideKeyboard = hideKeyboard;
            Text = label.Text;
            // Construct the control
            ConstructControl ();
        }
        // Invoke the Clicked event; called when ImageButton is tapped
        protected virtual void OnClicked ( EventArgs e )
        {
            if ( Clicked != null )
                Clicked ( this, e );
        }
        private void ConstructControl ()
        // Construct the control using a grid with a single cell
        {
            // Add action performed upon tap
            this.AddTap ( () => 
            {
                // Hide keyboard
                if ( HideKeyboard )
                    DependencyService.Get<IKeyboard> ().HideKeyboard ();
                // Fire the event 
                OnClicked ( EventArgs.Empty );
            });
            // Bind opacity of image and label to IsEnabled via a converter
            TheLabel.SetBinding ( OpacityProperty, new Binding ( "IsEnabled", converter: new BooleanToOpacityConverter (), source: this ) );
            TheImage.SetBinding ( OpacityProperty, new Binding ( "IsEnabled", converter: new BooleanToOpacityConverter (), source: this ) );
            // Stack image and label on top of each other in a grid with a single cell
            this.RowDefinitions.Add ( new RowDefinition { Height = new GridLength ( 1, GridUnitType.Auto ) } );
            this.ColumnDefinitions.Add ( new ColumnDefinition { Width = new GridLength ( 1, GridUnitType.Auto ) } );
            this.Children.Add ( TheImage, 0, 0 );   // Add image first, so overlaid label will be visible
            this.Children.Add ( TheLabel, 0, 0 );
        }
        public class BooleanToOpacityConverter : IValueConverter
        {
            public object Convert ( object value, Type targetType, object parameter, CultureInfo culture )
            {
                var isEnabled = ( value != null ) && (bool)value;
                return isEnabled ? 1 : 0.5;
            }
            public object ConvertBack ( object value, Type targetType, object parameter, CultureInfo culture )
            {
                throw new NotImplementedException ();
            }
        }
    }
    
    public static class GridExtensions
    {
        // Grid extension methods
        private static void AddTap ( this Grid grid, Action action )
        // Allows Grid to be tappable
        // action = method to call when Grid is tapped
        // Example:
        //          Grid grid = new Grid ();
        //          grid.AddTap ( () => MyMethod () );
        {
            grid.GestureRecognizers.Add ( new TapGestureRecognizer 
            {
                Command = new Command (action)
            });
        }
    }
    
    public interface IKeyboard
    {
        void HideKeyboard ();       // Hide the keyboard
    }
    
    iOS:
    
    [assembly: Xamarin.Forms.Dependency (typeof(Keyboard))]
    namespace MyApp.iOS
    {
        public class Keyboard : MyApp.IKeyboard
        {
            public Keyboard () {}
            public void HideKeyboard ()
            // Hides the keyboard
            {
                UIApplication.SharedApplication.KeyWindow.EndEditing ( true );
            }
        }
    }
    
    Android (not tested yet):
    
    [assembly: Xamarin.Forms.Dependency (typeof (Keyboard))]
    namespace MyApp.Droid
    {
        public class Keyboard : MyApp.IKeyboard
        {
            public Keyboard () {}
            public void HideKeyboard ()
            // Hides the keyboard
            {
                var context = Forms.Context;
                var inputMethodManager = context.GetSystemService ( Context.InputMethodService ) as InputMethodManager;
                if ( inputMethodManager != null && context is Activity ) 
                {
                    var activity = context as Activity;
                    var token = activity.CurrentFocus?.WindowToken;
                    inputMethodManager.HideSoftInputFromWindow ( token, HideSoftInputFlags.None );
                    activity.Window.DecorView.ClearFocus ();
                }
            }
        }
    }    
    
