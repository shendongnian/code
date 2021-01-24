     private void up_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
            {
                if (e.Delta < 0)
                {
                    scrollViewer.LineDown();
                }
                else
                {
                    scrollViewer.LineUp();
                }
    
            }
