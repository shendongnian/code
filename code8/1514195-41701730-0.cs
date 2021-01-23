    [assembly: ExportRenderer(typeof(Xamarin.Forms.Label), typeof(MyLabelRenderer))]
    namespace MyApp.CustomRenderers.Controls
    {
        public class MyLabelRenderer : LabelRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);
               
                if (Control != null)
                {
                    var font = new FontFamily(@"\Assets\Fonts\Lobster-Regular.ttf#Lobster-Regular");
    
                    if (e.NewElement != null)
                    {
                        switch (e.NewElement.FontAttributes)
                        {
                            case FontAttributes.None:
                                break;
                            case FontAttributes.Bold:
                                //set bold font etc
                                break;
                            case FontAttributes.Italic:
                                //set italic font etc
                                break;
                            default:
                                break;
                        }
                    }
                    Control.FontFamily = font;
                }
            }     
        }
