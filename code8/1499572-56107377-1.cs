    public class CustomMasterDetailRenderer :MasterDetailPageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<MasterDetailPage> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {   
                Control.CollapsedPaneWidth = 0;
                Control.CollapseStyle = Xamarin.Forms.PlatformConfiguration.WindowsSpecific.CollapseStyle.Partial;
                Control.MasterToolbarVisibility = Windows.UI.Xaml.Visibility.Collapsed;
                Control.DetailTitleVisibility = Windows.UI.Xaml.Visibility.Collapsed;
                Control.MasterTitleVisibility = Windows.UI.Xaml.Visibility.Collapsed;
                Control.ContentTogglePaneButtonVisibility = 
     Windows.UI.Xaml.Visibility.Collapsed;
            }
        }
    }
