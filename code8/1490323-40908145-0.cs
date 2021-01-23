    private DateTime mouseTimer;
    private void Scroller_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            mouseTimer = DateTime.Now;
          
            ScrollViewer scrollViewer = sender as ScrollViewer;
            if(scrollViewer.IsMouseCaptured)
            {
                scrollViewer.ReleaseAllTouchCaptures();
            }
            
            TimeSpan difference = DateTime.Now - mouseTimer;
                  if (difference.TotalSeconds < 1)
                   {
                    btn_Click(sender, e); //button you want or don't want to rise event
                   }
                  else
                  return;
        }
             
