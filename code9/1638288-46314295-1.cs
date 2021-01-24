    public sealed partial class MainPage : Page
    {
       public MainPage()
       {
           this.InitializeComponent();
           CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
           Window.Current.SetTitleBar(btnMenuPlace1);
           Window.Current.SizeChanged += Current_SizeChanged;
       }
       private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
       {
           var appView = ApplicationView.GetForCurrentView();
           if (appView.IsFullScreenMode)
           { 
               RemoveChild(btnMenuPlace1, btnMenuPlaceContent);
               btnMenuPlace2.Children.Add(btnMenuPlaceContent);            
           }
           else
           {
               RemoveChild(btnMenuPlace2, btnMenuPlaceContent);             
               btnMenuPlace1.Children.Add(btnMenuPlaceContent);
           }
           e.Handled = true;
       }
       public void RemoveChild(DependencyObject parent, UIElement child)
       {
           Grid parentAsPanel = VisualTreeHelper.GetParent(child) as Grid;
           if (parentAsPanel != null)
           {                
               parentAsPanel.Children.Remove(child);
               return;
           }
           var parentAsContentPresenter = parent as ContentPresenter;
           if (parentAsContentPresenter != null)
           {
               if (parentAsContentPresenter.Content == child)
               {
                   parentAsContentPresenter.Content = null;
               }
               return;
           }
           var parentAsContentControl = parent as ContentControl;
           if (parentAsContentControl != null)
           {
               if (parentAsContentControl.Content == child)
               {
                   parentAsContentControl.Content = null;
               }
               return;
           }
       }     
 
       private void ToggleFullScreenModeButton_Click(object sender, RoutedEventArgs e)
       {
           var view = ApplicationView.GetForCurrentView();
           if (view.IsFullScreenMode)
           {
               view.ExitFullScreenMode();                
           }
           else
           {
               if (view.TryEnterFullScreenMode())
               {
                   txtresult.Text = "full screen";
               }
               else
               {
                   txtresult.Text = "no full screen";
               }
           }
       }
    }
