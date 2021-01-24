        [assembly: ExportRenderer(typeof(TwoLineLabel), typeof(TwoLineLabelRenderer))]
    namespace MyApp.iOS
    {
        public class TwoLineLabelRenderer : LabelRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
            {
                base.OnElementChanged(e);
                Control.Lines = 2;
            }
        }
    }
