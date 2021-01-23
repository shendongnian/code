         private DateTime mouseTimer;
        private void UIElement_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mouseTimer = DateTime.Now;
            scrollviewer1.CaptureMouse();
            scrollMousePoint = e.GetPosition(scrollviewer1);
            hOff = scrollviewer1.HorizontalOffset;
           
        }
        private void scrollviewer1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TimeSpan difference = DateTime.Now - mouseTimer;
            if (difference.TotalSeconds < 1)
            {
                btn3_Click(sender, e);
            }
            else
                return;
        
        }
