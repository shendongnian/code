    public static class Attached
    {
        public static bool GetEnableUserScrollingObserver(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableUserScrollingObserverProperty);
        }
        public static void SetEnableUserScrollingObserver(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableUserScrollingObserverProperty, value);
        }
        public static readonly DependencyProperty EnableUserScrollingObserverProperty =
            DependencyProperty.RegisterAttached("EnableUserScrollingObserver", typeof(bool), typeof(Attached),
                new FrameworkPropertyMetadata(false, new PropertyChangedCallback(EnableUserScrollingObserverChanged)));
        private static void EnableUserScrollingObserverChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var s = d as ScrollBar;
            if (s != null)
            {
                s.Scroll -= Scrollbar_Scroll;
                if ((bool)e.NewValue)
                {
                    s.Scroll += Scrollbar_Scroll;
                }
            }
            else
            {
                // Using this on anything other than a ScrollBar sucks
                throw new InvalidOperationException("EnableUserScrollingObserver is designed for ScrollBar elements!");
            }
        }
        static void Scrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            var s = sender as ScrollBar;
            switch (e.ScrollEventType)
            {
                case ScrollEventType.EndScroll:
                    SetIsUserScrolling(s, false);
                    break;
                    /* All the things handled by default
                case ScrollEventType.First:
                    break;
                case ScrollEventType.LargeDecrement:
                    break;
                case ScrollEventType.LargeIncrement:
                    break;
                case ScrollEventType.Last:
                    break;
                case ScrollEventType.SmallDecrement:
                    break;
                case ScrollEventType.SmallIncrement:
                    break;
                case ScrollEventType.ThumbPosition:
                    break;
                case ScrollEventType.ThumbTrack:
                    break;
                     */
                default:
                    SetIsUserScrolling(s, true);
                    break;
            }
        }
        public static bool GetIsUserScrolling(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsUserScrollingProperty);
        }
        public static void SetIsUserScrolling(DependencyObject obj, bool value)
        {
            obj.SetValue(IsUserScrollingProperty, value);
        }
        public static readonly DependencyProperty IsUserScrollingProperty =
            DependencyProperty.RegisterAttached("IsUserScrolling", typeof(bool), typeof(Attached),
                new FrameworkPropertyMetadata(false));
    }
