    public partial class ChannelsControl : UserControl
    {
        public static readonly DependencyProperty SpriteCountProperty =
            DependencyProperty.Register(
                nameof(SpriteCount), typeof(string), typeof(ChannelsControl));
        public string SpriteCount
        {
            get { return (string)GetValue(SpriteCountProperty); }
            set { SetValue(SpriteCountProperty, value); }
        }
        ...
    }
