    [assembly: ExportRenderer(typeof(TabbedPage), typeof(MyTabbedPageRenderer))]
    namespace MyRenderer.UWP
    {
      public class MyTabbedPageRenderer : TabbedPageRenderer
      {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.HeaderTemplate = GetStyledHeaderTemplate();
            }
        }
      }
    
      private Windows.UI.Xaml.DataTemplate GetStyledHeaderTemplate()
      {
        string xaml = @"
    <DataTemplate 
        xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
        xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
        xmlns:tint=""using:MyNamespace.UI"">
    <StackPanel Orientation=""Horizontal"">
        <tint:ImageTinted Source=""{Binding Icon}""/>
        <TextBlock Text=""{Binding Title}"" FontFamily=""Segoe UI"" 
    FontSize=""13"" />
    </StackPanel>
    </DataTemplate>";
        return (Windows.UI.Xaml.DataTemplate)XamlReader.Load(xaml);
      }
    }
