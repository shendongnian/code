    public class ToolTipRendererUWP : VisualElementRenderer<StackLayout, StackPanel>
    {
        
        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);
            if (Element == null)
                return;            
            
            if (!string.IsNullOrEmpty(Element.ClassId))
            {
                ToolTip toolTip = new ToolTip();
                toolTip.Content = Element.ClassId;
                ToolTipService.SetToolTip(this, toolTip);
            }         
        }}
