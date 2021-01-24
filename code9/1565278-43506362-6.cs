    public sealed class QualityTransportControls: MediaTransportControls
    {
        //store the old quality for the custom event
        private int oldQuality = 144;
        private int quality = 144;
        public int Quality
        {
            get { return quality; }
            set {
                //update oldQuality
                oldQuality = quality;
                quality = value;
                //this method is responsible for raising the event
                OnQualityChanged();
            }
        }
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
            Quality = 144;
        }
        private void SetQuality240(object sender, TappedRoutedEventArgs e)
        {
            Quality = 244;
        }
        private EventRegistrationTokenTable<EventHandler<QualityChangedEventArgs>> m_NumberChangedTokenTable = null;
        //this is your custom event which you can use within xaml
        public event EventHandler<QualityChangedEventArgs> QualityChanged
        {
            add
            {
                EventRegistrationTokenTable<EventHandler<QualityChangedEventArgs>>
                    .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
                    .AddEventHandler(value);
            }
            remove
            {
                EventRegistrationTokenTable<EventHandler<QualityChangedEventArgs>>
                    .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
                    .RemoveEventHandler(value);
            }
        }
        internal void OnQualityChanged()
        {
            //here you raise the event for every subscriber
            EventRegistrationTokenTable<EventHandler<QualityChangedEventArgs>>
            .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
            .InvocationList?.Invoke(this, new QualityChangedEventArgs(oldQuality, Quality));
        }
    }
