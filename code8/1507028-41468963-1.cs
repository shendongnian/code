        public class MediaElementAttached : DependencyObject
        {
            #region IsPlaying Property
    
            public static DependencyProperty IsPlayingProperty =
                DependencyProperty.RegisterAttached(
                    "IsPlaying", typeof(bool), typeof(AttachedProperty),
                    new PropertyMetadata(null, OnIsPlayingChanged));
            public static bool GetIsPlaying(DependencyObject d)
            {
                return (bool)d.GetValue(IsPlayingProperty);
            }
            public static void SetIsPlaying(DependencyObject d, bool value)
            {
                d.SetValue(IsPlayingProperty, value);
            }
            private static void OnIsPlayingChanged(
                DependencyObject obj,
                DependencyPropertyChangedEventArgs args)
            {
                MediaElement me = obj as MediaElement;
                if (me == null)
                    return;
                bool isPlaying = (bool)args.NewValue;
                if (isPlaying)
                    me.Play();
                else
                    me.Stop();
            }
    
            #endregion
        }
