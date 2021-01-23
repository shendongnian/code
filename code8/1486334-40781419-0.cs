     private void UIElement_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source == btn9)
            {  btn9_Click(sender, e); }
            scrollviewer1.CaptureMouse();
            scrollMousePoint = e.GetPosition(scrollviewer1);
            hOff = scrollviewer1.HorizontalOffset;
            scrollviewer1.CaptureMouse();
        }
      private void btn9_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("i AM WORKING");
        }
   
