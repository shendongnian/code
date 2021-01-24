     public class ToolTipRendererMAC : VisualElementRenderer<StackLayout>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
            if (Element == null)
                return;
            if (!string.IsNullOrEmpty(Element.ClassId))
                this.ToolTip = Element.ClassId;
        }}
