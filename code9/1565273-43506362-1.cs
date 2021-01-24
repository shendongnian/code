    public sealed class QualityTransportControls: MediaTransportControls
    {
        public QualityTransportControls()
        {
            this.DefaultStyleKey = typeof(QualityTransportControls);
        }
        protected override void OnApplyTemplate()
        {
            MenuFlyoutItem flyoutItem = GetTemplateChild("Quality144p") as MenuFlyoutItem;
            flyoutItem.Tapped += SetQuality144;
            MenuFlyoutItem flyoutItem2 = GetTemplateChild("Quality240p") as MenuFlyoutItem;
            flyoutItem.Tapped += SetQuality240;
            base.OnApplyTemplate();
        }
        private void SetQuality144(object sender, TappedRoutedEventArgs e)
        {
            //set quality to 144p
        }
        private void SetQuality240(object sender, TappedRoutedEventArgs e)
        {
            //set quality to 240p
        }
    }
