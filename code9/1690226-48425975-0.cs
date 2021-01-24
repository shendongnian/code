    public partial class App
    {
       protected override void OnActivated(IActivatedEventArgs args)
      {
          if (args.Kind == ActivationKind.Protocol)
          {
                Frame rootFrame = Window.Current.Content as Frame;
                if (rootFrame == null)
                {
                    rootFrame = new Frame();
                    rootFrame.NavigationFailed += OnNavigationFailed;
                    Window.Current.Content = rootFrame;
                }
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                Window.Current.Activate();
          }
       }
    }
