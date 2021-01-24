        private async void PlayNextFile()
        {
            while (true)
            {
                if (currentState == PlayerState.Started)
                {
                    //if we find the next slide then play it
                    AudioSlide slideToPlay = FindNextSlide();
                    if (slideToPlay != null)
                    {
                        PlaySlide(slideToPlay);
                        return;
                    }
                    MedianLog.Log.Instance.LogDebug("Did not find a slide to play now, will check again in a second");
                    await Task.Delay(1000);
                }
                else
                {
                    return;
                }
            }      
        }
