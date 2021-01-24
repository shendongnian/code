    public class MyButtonRenderer : ButtonRenderer
    {
        ....
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(Button.IsEnabled))
            {
                Element.TextColor = Element.IsEnabled ? Color.White : Color.Gray;
            }
        }
        ...
    }
