    public class DynamicContent : ContentControl
    {
        public bool ShowContent
        {
            get { return (bool)GetValue(ShowContentProperty); }
            set { SetValue(ShowContentProperty, value); }
        }
        public static readonly DependencyProperty ShowContentProperty =
            DependencyProperty.Register("ShowContent", typeof(bool), typeof(DynamicContent),
            new PropertyMetadata(false,
                (sender, e) => ((DynamicContent)sender).ChangeContent((bool)e.NewValue)));
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            ChangeContent(ShowContent);
        }
        void ChangeContent(bool show) => Template = show ? (ControlTemplate)Content : null;
    }
