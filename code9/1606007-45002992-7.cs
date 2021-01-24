        [assembly: ExportRenderer(typeof(RoundedEditor), 
        typeof(RoundedEditorRenderer))]
        namespace RoundedEditorDemo.UWP
        {
            public class RoundedEditorRenderer:EditorRenderer
            {
                protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
                {
                    base.OnElementChanged(e);
                    if (Control != null)
                    {
                        Windows.UI.Xaml.ResourceDictionary dic = new Windows.UI.Xaml.ResourceDictionary();
                        dic.Source = new Uri("ms-appx:///RoundedEditorRes.xaml");
                        Control.Style = dic["RoundedEditorStyle"] as Windows.UI.Xaml.Style;
                    }
                }
            }
        }
