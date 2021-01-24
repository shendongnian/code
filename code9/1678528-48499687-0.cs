    private void SetContentViewVisible(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(
                  () =>
                  {
                      timer.Dispose();
                      scrollView.Opacity = 1;
                      stackView.IsVisible = false;
                      timer.Stop();
                      DisplayAlert(SaySomething);
                  });
        }
