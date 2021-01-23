    int counter = 0;
        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MyTappedClass SingleTapInstance = new MyTappedClass()
            {
                Handled = e.Handled,
                OriginalSource = e.OriginalSource,
                PointerDeviceType = e.PointerDeviceType
            };
            HandleBothTapEvents(SingleTapInstance);
        }
        private void Button_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            MyTappedClass DoubleTapInstance = new MyTappedClass()
            {
                Handled = e.Handled,
                OriginalSource = e.OriginalSource,
                PointerDeviceType = e.PointerDeviceType
            };
            HandleBothTapEvents(DoubleTapInstance);
        }
        private void HandleBothTapEvents(MyTappedClass TapData)
        {
            if (TapData != null)
            {
                counter++;
                Hello.Content = counter.ToString();
            }
            else
                throw new Exception("No Tap event data transfered");
        }
