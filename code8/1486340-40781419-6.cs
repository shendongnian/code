     private void UIElement_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source == btn3)
            {  btn3_Click(sender, e); }
            
            scrollMousePoint = e.GetPosition(scrollviewer1);
            hOff = scrollviewer1.HorizontalOffset;
            scrollviewer1.CaptureMouse();
        }
      private void btn9_Click(object sender, RoutedEventArgs e)
        {
            label2.Content = "i AM WORKING"; //You can press and still scroll
        }
