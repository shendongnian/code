    public async Task ScrollMessagesToEndAsync() //Adding Async to method name, also try to return Task and await this method in the calling code as well
        {
            await Task.Delay(300); //Sometimes code runs too fast and a delay is needed, you may test whether only a specific platform needs the delay
            StackLayout messagesContent = (messagesScrollView.Content as StackLayout);
            var frame = messagesContent.Children.LastOrDefault();
            if (frame != null)
            {
                    Device.BeginInvokeOnMainThread(async () => await messagesScrollView.ScrollToAsync(frame, ScrollToPosition.MakeVisible, true)); //You could try passing in false to disable animation and see if that helps
            }
        }
