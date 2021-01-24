        private void Expander_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = e.OriginalSource as FrameworkElement;
            if(fe is ToggleButton && fe.Name == "HeaderSite")
            {
                Trace.WriteLine("Clicked in expander header");
            }
         }
