    using Windows.UI.Xaml;
    using Windows.UI.ViewManagement;
    
    public sealed partial class MainPage : Page
    {
      public MainPage()
      {
        InitializeComponent();
        // Every view gets an initial SizeChanged, so we will do all our 
        // work there. This means that our view also responds to dynamic
        // changes in user interaction mode.
        Window.Current.SizeChanged += SizeChanged;
      }
    
      private void SizeChanged(object sender, RoutedEventArgs e)
      {
        switch(UIViewSettings.GetForCurrentView().UserInteractionMode)
        {
          case UserInteractionMode.Mouse:
            VisualStateManager.GoToState(this, "MouseLayout", true);
            break;
    
          case UserInteractionMode.Touch:
          default:
            VisualStateManager.GoToState(this, "TouchLayout", true);
            break;
        }
      }
    }
